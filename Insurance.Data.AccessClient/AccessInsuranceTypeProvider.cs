using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Insurance.Data.Bases;
using Insurance.Data.Model;

namespace Insurance.Data.AccessClient
{
    class AccessInsuranceTypeProvider:InsuranceTypeProvider
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
        /// Creates a new <see cref="AccessInsuranceTypeProvider"/> instance.
		/// </summary>
        public AccessInsuranceTypeProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="AccessInsuranceTypeProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public AccessInsuranceTypeProvider(string connectionString, string providerInvariantName)
	    {
		    this._connectionString = connectionString;
		    this._providerInvariantName = providerInvariantName;
	    }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到险种实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>险种实体。</returns>
        private static InsuranceTypeInfo ConvertToInsuranceTypeInfo(IDataRecord dr)
        {
            var obj = new InsuranceTypeInfo();
            obj.Id = long.Parse(dr["Id"].ToString());
            obj.Code = dr["Code"].ToString();
            obj.Name = dr["Name"].ToString();

            return obj;
        }

        /// <summary>
        /// 获取新插入记录的Id。
        /// </summary>
        /// <returns>新插入记录的Id。</returns>
        private long GetIdentity(OleDbTransaction trans)
        {
            var oRet = AccessHelper.ExecuteScalar(trans, "Select max(Id) From InsuranceType ");
            return long.Parse(oRet.ToString());
        }
        #endregion

        #region Overrides of InsuranceTypeProvider

        /// <summary>
        /// 添加险种。
        /// </summary>
        /// <param name="obj">险种对象。</param>
        /// <returns>险种Id。</returns>
        public override long Insert(InsuranceTypeInfo obj)
        {
            var sqlStatement = "Insert Into InsuranceType ( Code,Name) Values ( @Code,@Name)";
            var parms = new[]
                {
                    new OleDbParameter("@Code",OleDbType.VarChar,10){Value = obj.Code}, 
                    new OleDbParameter("@Name", OleDbType.VarWChar, 50) { Value = obj.Name }
                };
            using(var conn = new OleDbConnection(this.ConnectionString))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    AccessHelper.ExecuteNonQuery(trans, sqlStatement, parms);
                    obj.Id = this.GetIdentity(trans);
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
        /// 修改险种。
        /// </summary>
        /// <param name="obj">险种对象。</param>
        /// <returns>bool</returns>
        public override bool Update(InsuranceTypeInfo obj)
        {
            var sqlStatement = "Update InsuranceType Set Name = @Name Where Id = @Id";
            var parms = new[]
                {
                    new OleDbParameter("@Code", OleDbType.VarChar, 10) {Value = obj.Code},
                    new OleDbParameter("@Name", OleDbType.VarWChar, 50) {Value = obj.Name},
                    new OleDbParameter("@Id", OleDbType.BigInt) {Value = obj.Id}
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
        /// 删除险种。
        /// </summary>
        /// <param name="obj">险种对象。</param>
        /// <returns>bool</returns>
        public override bool Delete(InsuranceTypeInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 删除险种。
        /// </summary>
        /// <param name="id">险种Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(long id)
        {
            var sqlStatement = "Delete From InsuranceType Where Id = @Id";
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
        /// 获取所有险种。
        /// </summary>
        /// <returns>险种集合。</returns>
        public override List<InsuranceTypeInfo> GetAll()
        {
            var sqlStatement = "Select * From InsuranceType";
            var objs = new List<InsuranceTypeInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement);
            while(dr.Read())
            {
                objs.Add(ConvertToInsuranceTypeInfo(dr));
            }
            dr.Close();
            return objs;
        }

        #endregion
    }
}
