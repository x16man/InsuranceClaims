using System;
using System.Data.OleDb;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Insurance.Data.Bases;
using Insurance.Data.Model;
namespace Insurance.Data.AccessClient
{
    class AccessClaimTypeProvider:ClaimTypeProvider
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
		/// Creates a new <see cref="AccessClaimTypeProvider"/> instance.
		/// </summary>
		public AccessClaimTypeProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="AccessClaimTypeProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public AccessClaimTypeProvider(string connectionString, string providerInvariantName)
	    {
		    this.ConnectionString = connectionString;
		    this.ProviderInvariantName = providerInvariantName;
	    }
        #endregion

        

        #region Overrides of ClaimTypeProvider

        /// <summary>
        /// 添加理赔类型。
        /// </summary>
        /// <param name="obj">理赔类型实体。</param>
        /// <returns>理赔类型Id。</returns>
        public override bool Insert(ClaimTypeInfo obj)
        {
            var sqlStatement = "Insert Into ClaimTypes ([Id],[Name]) Values (@Id,@Name)";
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
        /// 更改理赔类型。
        /// </summary>
        /// <param name="obj">理赔类型实体。</param>
        /// <returns>bool</returns>
        public override bool Update(ClaimTypeInfo obj)
        {
            var sqlStatement = "Update ClaimTypes Set [Id] = @Id,[Name]=@Name Where Id = @OldId";
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
        /// 删除理赔类型。
        /// </summary>
        /// <param name="id">理赔类型Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(string id)
        {
            var sqlStatement = "Delete From ClaimTypes Where Id = @Id";
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
        /// 获取所有理赔类型。
        /// </summary>
        /// <returns>理赔类型集合。</returns>
        public override List<ClaimTypeInfo> GetAll()
        {
            var sqlStatement = "Select [Id],[Name] From ClaimTypes";
            var objs = new List<ClaimTypeInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString,sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取理赔类型。
        /// </summary>
        /// <param name="id">理赔类型Id。</param>
        /// <returns>理赔类型实体。</returns>
        public override ClaimTypeInfo GetById(string id)
        {
            var sqlStatement = "Select [Id],[Name] From ClaimTypes Where [Id] = @Id";
            var parms = new[] {new OleDbParameter("@Id", OleDbType.VarChar,10) {Value = id}};
            ClaimTypeInfo obj = null;
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
