using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Insurance.Data.Bases;
using Insurance.Data.Model;

namespace Insurance.Data.AccessClient
{
    class AccessClaimProvider : ClaimProvider
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
        /// Creates a new <see cref="AccessClaimProvider"/> instance.
        /// </summary>
        public AccessClaimProvider()
        {
        }
        /// <summary>
        /// Creates a new <see cref="AccessClaimProvider"/> instance.
        /// Uses connection string to connect to datasource.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public AccessClaimProvider(string connectionString, string providerInvariantName)
        {
            this._connectionString = connectionString;
            this._providerInvariantName = providerInvariantName;
        }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到保险理赔单实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>保险理赔单实体。</returns>
        private static ClaimInfo ConvertToClaimInfo(IDataRecord dr)
        {
            var obj = new ClaimInfo();
            obj.Id = long.Parse(dr["Id"].ToString());
            obj.InsuranceId = long.Parse(dr["InsuranceId"].ToString());
            obj.ClaimNo = dr["ClaimNo"].ToString();
            obj.ClaimName = dr["ClaimName"] == DBNull.Value ? string.Empty : dr["ClaimName"].ToString();
            obj.ClaimDate = DateTime.Parse(dr["ClaimDate"].ToString());
            obj.SubTotal = decimal.Parse(dr["SubTotal"].ToString());
            obj.Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString();

            return obj;
        }

        /// <summary>
        /// 获取新插入记录的Id。
        /// </summary>
        /// <returns>新插入记录的Id。</returns>
        private long GetIdentity(OleDbTransaction trans)
        {
            var oRet = AccessHelper.ExecuteScalar(trans, "Select max(Id) From Claims ");
            return long.Parse(oRet.ToString());
        }
        #endregion

        #region Overrides of ClaimProvider

        /// <summary>
        /// 添加保险理赔单。
        /// </summary>
        /// <param name="obj">保险理赔单实体。</param>
        /// <returns>保险理赔单Id。</returns>
        public override long Insert(ClaimInfo obj)
        {
            var sqlStatement = "Insert Into Claims ([InsuranceId],[ClaimNo],[ClaimName],[ClaimDate],[SubTotal],[Remark]) Values (@InsuranceId,@ClaimNo,@ClaimName,@ClaimDate,@SubTotal,@Remark)";
            var parms = new[]
                            {
                                new OleDbParameter("@InsuranceId",OleDbType.BigInt){Value = obj.InsuranceId},
                                new OleDbParameter("@ClaimNo",OleDbType.VarWChar,50){Value = obj.ClaimNo},
                                new OleDbParameter("@ClaimName",OleDbType.VarWChar,50){Value = string.IsNullOrEmpty(obj.ClaimName)?DBNull.Value:(object)obj.ClaimName},
                                new OleDbParameter("@ClaimDate",OleDbType.Date){Value = obj.ClaimDate},
                                new OleDbParameter("@SubTotal",OleDbType.Decimal){Value = obj.SubTotal},
                                new OleDbParameter("@Remark",OleDbType.VarWChar,255){Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
                            };
            using (var conn = new OleDbConnection(this.ConnectionString))
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
        /// 更改保险理赔单。
        /// </summary>
        /// <param name="obj">保险理赔单实体。</param>
        /// <returns>bool</returns>
        public override bool Update(ClaimInfo obj)
        {
            var sqlStatement = "Update Claims Set [InsuranceId] = @InsuranceId,[ClaimNo] = @ClaimNo,[ClaimName] = @ClaimName,[ClaimDate]=@ClaimDate,[SubTotal]=@SubTotal,[Remark]=@Remark Where Id = @Id";
            var parms = new[]
                            {
                                new OleDbParameter("@InsuranceId",OleDbType.BigInt){Value = obj.InsuranceId},
                                new OleDbParameter("@ClaimNo",OleDbType.VarWChar,50){Value = obj.ClaimNo},
                                new OleDbParameter("@ClaimName",OleDbType.VarWChar,50){Value = string.IsNullOrEmpty(obj.ClaimName)?DBNull.Value:(object)obj.ClaimName},
                                new OleDbParameter("@ClaimDate",OleDbType.Date){Value = obj.ClaimDate},
                                new OleDbParameter("@SubTotal",OleDbType.Decimal){Value = obj.SubTotal},
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
        /// 删除保险理赔单。
        /// </summary>
        /// <param name="obj">保险理赔单实体。</param>
        /// <returns>bool</returns>
        public override bool Delete(ClaimInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 删除保险理赔单。
        /// </summary>
        /// <param name="id">保险理赔单Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(long id)
        {
            var sqlStatement = "Delete From Claims Where Id = @Id";
            var parms = new[] { new OleDbParameter("@Id", OleDbType.BigInt) { Value = id } };
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
        /// 获取所有保险理赔单集合。
        /// </summary>
        /// <returns>保险理赔单集合。</returns>
        public override List<ClaimInfo> GetAll()
        {
            var sqlStatement = "Select [Id],[InsuranceId],[ClaimNo],[ClaimName],[ClaimDate],[SubTotal],[Remark] From Claims";
            var objs = new List<ClaimInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToClaimInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据保险单Id获取保险理赔单集合。
        /// </summary>
        /// <param name="insuranceId">保险单Id。</param>
        /// <returns>保险理赔单集合。</returns>
        public override List<ClaimInfo> GetByInsuranceId(long insuranceId)
        {
            var sqlStatement = "Select [Id],[InsuranceId],[ClaimNo],[ClaimName],[ClaimDate],[SubTotal],[Remark] From Claims Where InsuranceId = @InsuranceId";
            var parms = new[] { new OleDbParameter("@InsuranceId", OleDbType.BigInt) { Value = insuranceId } };
            var objs = new List<ClaimInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement, parms);
            while (dr.Read())
            {
                objs.Add(ConvertToClaimInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据保险理赔单Id获取保险理赔单。
        /// </summary>
        /// <param name="id">保险理赔单Id。</param>
        /// <returns>保险理赔单。</returns>
        public override ClaimInfo GetById(long id)
        {
            var sqlStatement = "Select [Id],[InsuranceId],[ClaimNo],[ClaimName],[ClaimDate],[SubTotal],[Remark] From Claims Where Id = @Id";
            var parms = new[] { new OleDbParameter("@Id", OleDbType.BigInt) { Value = id } };
            ClaimInfo obj = null;
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToClaimInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
