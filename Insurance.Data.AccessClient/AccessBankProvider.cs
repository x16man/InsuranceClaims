using System;
using System.Data.OleDb;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Insurance.Data.Bases;
using Insurance.Data.Model;
namespace Insurance.Data.AccessClient
{
    class AccessBankProvider:BankProvider
    {
        #region Field
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
        /// </summary>
        /// <value>The name of the provider invariant.</value>
        public string ProviderInvariantName { get; set; }

        #endregion

        #region CTOR
        /// <summary>
		/// Creates a new <see cref="AccessBankProvider"/> instance.
		/// </summary>
		public AccessBankProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="AccessBankProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public AccessBankProvider(string connectionString, string providerInvariantName)
	    {
		    this.ConnectionString = connectionString;
		    this.ProviderInvariantName = providerInvariantName;
	    }
        #endregion

        

        #region Overrides of BankProvider

        /// <summary>
        /// 添加银行。
        /// </summary>
        /// <param name="obj">银行实体。</param>
        /// <returns>银行Id。</returns>
        public override bool Insert(BankInfo obj)
        {
            var sqlStatement = "Insert Into Banks ([Id],[Name]) Values (@Id,@Name)";
            var parms = new[]
                            {
                                new OleDbParameter("@Id", OleDbType.VarChar,10) {Value = obj.Id},
                                new OleDbParameter("@Name", OleDbType.VarWChar, 50) {Value = obj.Name}
                            };
            using (var conn = new OleDbConnection(this.ConnectionString))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    AccessHelper.ExecuteNonQuery(trans, sqlStatement, parms);
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Logger.Error(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
            
        }

        /// <summary>
        /// 更改银行。
        /// </summary>
        /// <param name="obj">银行实体。</param>
        /// <returns>bool</returns>
        public override bool Update(BankInfo obj)
        {
            var sqlStatement = "Update Banks Set [Id] = @Id,[Name]=@Name Where Id = @OldId";
            var parms = new[]
                            {
                                new OleDbParameter("@Id", OleDbType.VarChar,10) {Value = obj.Id},
                                new OleDbParameter("@OldId", OleDbType.VarChar,10) {Value = obj.OldId},
                                new OleDbParameter("@Name", OleDbType.VarWChar, 50) {Value = obj.Name}
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
        /// 删除银行。
        /// </summary>
        /// <param name="id">银行Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(string id)
        {
            var sqlStatement = "Delete From Banks Where Id = @Id";
            var parms = new[]
                            {
                                new OleDbParameter("@Id",OleDbType.VarChar,10){Value = id} 
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
        /// 获取所有银行。
        /// </summary>
        /// <returns>银行集合。</returns>
        public override List<BankInfo> GetAll()
        {
            var sqlStatement = "Select [Id],[Name] From Banks";
            var objs = new List<BankInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString,sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取银行。
        /// </summary>
        /// <param name="id">银行Id。</param>
        /// <returns>银行实体。</returns>
        public override BankInfo GetById(string id)
        {
            var sqlStatement = "Select [Id],[Name] From Banks Where [Id] = @Id";
            var parms = new[] {new OleDbParameter("@Id", OleDbType.VarChar,10) {Value = id}};
            BankInfo obj = null;
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToObject(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
