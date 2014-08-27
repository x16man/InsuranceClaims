using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Insurance.Data.Bases;
using Insurance.Data.Model;
namespace Insurance.Data.AccessClient
{
    class AccessCustomerProvider:CustomerProvider
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
		/// Creates a new <see cref="AccessCustomerProvider"/> instance.
		/// </summary>
		public AccessCustomerProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="AccessCustomerProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public AccessCustomerProvider(string connectionString, string providerInvariantName)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到客户实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>客户实体。</returns>
        private static CustomerInfo ConvertToCustomerInfo(IDataRecord dr)
        {
            var obj = new CustomerInfo();
            obj.Id = long.Parse(dr["Id"].ToString());
            obj.CategoryId = long.Parse(dr["CategoryId"].ToString());
            obj.Name = dr["Name"].ToString();
            obj.Address = dr["Address"] == DBNull.Value ? string.Empty : dr["Address"].ToString();
            obj.Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString();

            return obj;
        }

        /// <summary>
        /// 获取新插入记录的Id。
        /// </summary>
        /// <returns>新插入记录的Id。</returns>
        private long GetIdentity(OleDbTransaction trans)
        {
            var oRet = AccessHelper.ExecuteScalar(trans, "Select max(Id) From Customers ");
            return long.Parse(oRet.ToString());
        }
        #endregion

        #region Overrides of CustomerProvider

        /// <summary>
        /// 添加客户。
        /// </summary>
        /// <param name="obj">客户实体。</param>
        /// <returns>客户Id。</returns>
        public override long Insert(CustomerInfo obj)
        {
            var sqlStatement = "Insert Into Customers ([CategoryId],[Name],[Address],[Remark]) Values (@CategoryId,@Name,@Address,@Remark)";
            var parms = new[]
                            {
                                new OleDbParameter("@CategoryId", OleDbType.BigInt) {Value = obj.CategoryId},
                                new OleDbParameter("@Name", OleDbType.VarWChar, 50) {Value = obj.Name},
                                new OleDbParameter("@Address",OleDbType.VarWChar,50){Value = string.IsNullOrEmpty(obj.Address)?DBNull.Value:(object)obj.Address}, 
                                new OleDbParameter("@Remark", OleDbType.VarWChar, 255) {Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
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
                    Logger.Error(ex.Message);
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            
        }

        /// <summary>
        /// 更改客户。
        /// </summary>
        /// <param name="obj">客户实体。</param>
        /// <returns>bool</returns>
        public override bool Update(CustomerInfo obj)
        {
            var sqlStatement = "Update Customers Set [CategoryId] = @CategoryId,[Name]=@Name,[Address]=@Address,[Remark]=@Remark Where Id = @Id";
            var parms = new[]
                            {
                                new OleDbParameter("@CategoryId", OleDbType.BigInt) {Value = obj.CategoryId},
                                new OleDbParameter("@Name", OleDbType.VarWChar, 50) {Value = obj.Name},
                                new OleDbParameter("@Address",OleDbType.VarWChar,50){Value = string.IsNullOrEmpty(obj.Address)?DBNull.Value:(object)obj.Address}, 
                                new OleDbParameter("@Remark", OleDbType.VarWChar, 255) {Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
                                new OleDbParameter("@Id",OleDbType.BigInt){Value = obj.Id}, 
                            };
            try
            {
                AccessHelper.ExecuteNonQuery(this.ConnectionString, sqlStatement, parms);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除客户。
        /// </summary>
        /// <param name="obj">客户实体。</param>
        /// <returns>bool</returns>
        public override bool Delete(CustomerInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 删除客户。
        /// </summary>
        /// <param name="id">客户Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(long id)
        {
            var sqlStatement = "Delete From Customers Where Id = @Id";
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
                Logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取所有客户。
        /// </summary>
        /// <returns>客户集合。</returns>
        public override List<CustomerInfo> GetAll()
        {
            var sqlStatement = "Select [Id],[CategoryId],[Name],[Address],[Remark] From Customers";
            var objs = new List<CustomerInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString,sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToCustomerInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取客户。
        /// </summary>
        /// <param name="id">客户Id。</param>
        /// <returns>客户实体。</returns>
        public override CustomerInfo GetById(long id)
        {
            var sqlStatement = "Select [Id],[CategoryId],[Name],[Address],[Remark] From Customers Where [Id] = @Id";
            var parms = new[] {new OleDbParameter("@Id", OleDbType.BigInt) {Value = id},};
            CustomerInfo obj = null;
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToCustomerInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
