using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Insurance.Data.Bases;
using Insurance.Data.Model;

namespace Insurance.Data.AccessClient
{
    class AccessInsuranceProvider:InsuranceProvider
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string _connectionString;
        string _providerInvariantName;

        #endregion

        #region Property
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString
        {
            get { return this._connectionString; }
            set { this._connectionString = value; }
        }
        /// <summary>
        /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
        /// </summary>
        /// <value>The name of the provider invariant.</value>
        public string ProviderInvariantName
        {
            get { return this._providerInvariantName; }
            set { this._providerInvariantName = value; }
        }

        #endregion

        #region CTOR
        /// <summary>
        /// Creates a new <see cref="AccessInsuranceProvider"/> instance.
		/// </summary>
        public AccessInsuranceProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="AccessInsuranceProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public AccessInsuranceProvider(string connectionString, string providerInvariantName)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到保险单实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>保险单实体。</returns>
        private static InsuranceInfo ConvertToInsuranceInfo(IDataRecord dr)
        {
            var obj = new InsuranceInfo();
            obj.Id = long.Parse(dr["Id"].ToString());
            obj.CustomerId = long.Parse(dr["CustomerId"].ToString());
            obj.Code = dr["Code"].ToString();
            obj.Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString();

            return obj;
        }

        /// <summary>
        /// 获取新插入记录的Id。
        /// </summary>
        /// <returns>新插入记录的Id。</returns>
        private long GetIdentity(OleDbTransaction trans)
        {
            var oRet = AccessHelper.ExecuteScalar(trans, "Select max(Id) From Insurances ");
            return long.Parse(oRet.ToString());
        }
        #endregion

        #region Overrides of InsuranceProvider

        /// <summary>
        /// 添加保险单。
        /// </summary>
        /// <param name="obj">保险单实体。</param>
        /// <returns>保险单Id。</returns>
        public override long Insert(InsuranceInfo obj)
        {
            var sqlStatement = "Insert Into Insurances ([Code],[CustomerId],[Remark]) Values (@Code,@CustomerId,@Remark)";
            var parms = new[]
                            {
                                new OleDbParameter("@Code",OleDbType.VarWChar,50){Value = obj.Code},
                                new OleDbParameter("@CustomerId",OleDbType.BigInt){Value = obj.CustomerId,},
                                new OleDbParameter("@Remark",OleDbType.VarWChar,255){Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},

                            };
            using(var conn = new OleDbConnection(this.ConnectionString))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    AccessHelper.ExecuteNonQuery(trans, sqlStatement, parms);
                    obj.Id = GetIdentity(trans);
                    trans.Commit();
                    return obj.Id;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Logger.Error(ex.Message, ex);
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            
        }

        /// <summary>
        /// 更改保险单。
        /// </summary>
        /// <param name="obj">保险单实体。</param>
        /// <returns>bool</returns>
        public override bool Update(InsuranceInfo obj)
        {
            var sqlStatement = "Update Insurances Set [Code] = @Code,[CustomerId] = @CustomerId,[Remark] = @Remark Where Id = @Id";
            var parms = new[]
                            {
                                new OleDbParameter("@Code",OleDbType.VarWChar,50){Value = obj.Code},
                                new OleDbParameter("@CustomerId",OleDbType.BigInt){Value = obj.CustomerId,},
                                new OleDbParameter("@Remark",OleDbType.VarWChar,255){Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
                                new OleDbParameter("@Id",OleDbType.BigInt){Value = obj.Id}, 
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(this.ConnectionString, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 删除保险单。
        /// </summary>
        /// <param name="obj">保险单实体。</param>
        /// <returns>bool</returns>
        public override bool Delete(InsuranceInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 删除保险单。
        /// </summary>
        /// <param name="id">保险单Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(long id)
        {
            var sqlStatement = "Delete From Insurances Where Id = @Id";
            var parms = new[]
                            {
                                new OleDbParameter("@Id",OleDbType.BigInt){Value = id}, 
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(this.ConnectionString, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return false;
            }
        }

        /// <summary>
        /// 获取所有保险单。
        /// </summary>
        /// <returns>保险单集合。</returns>
        public override List<InsuranceInfo> GetAll()
        {
            var sqlStatement = "Select [Id],[Code],[CustomerId],[Remark] From Insurances";
            var objs = new List<InsuranceInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToInsuranceInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据客户Id获取保险单集合。
        /// </summary>
        /// <param name="customerId">客户Id。</param>
        /// <returns>保险单集合。</returns>
        public override List<InsuranceInfo> GetByCustomerId(long customerId)
        {
            var sqlStatement = "Select [Id],[Code],[CustomerId],[Remark] From Insurances Where [CustomerId] = @CustomerId";
            var parms = new[] {new OleDbParameter("@CustomerId", OleDbType.BigInt) {Value = customerId}};
            var objs = new List<InsuranceInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement,parms);
            while (dr.Read())
            {
                objs.Add(ConvertToInsuranceInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据保险单Id获取保险单。
        /// </summary>
        /// <param name="id">保险单Id。</param>
        /// <returns>保险单实体。</returns>
        public override InsuranceInfo GetById(long id)
        {
            var sqlStatement = "Select [Id],[Code],[CustomerId],[Remark] From Insurances Where [Id] = @Id";
            var parms = new[] { new OleDbParameter("@Id", OleDbType.BigInt) { Value = id } };
            InsuranceInfo obj = null;
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToInsuranceInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
