using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Insurance.Data.Bases;
using Insurance.Data.Model;
namespace Insurance.Data.AccessClient
{
    class AccessStaffProvider:StaffProvider
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
		/// Creates a new <see cref="AccessStaffProvider"/> instance.
		/// </summary>
		public AccessStaffProvider()
		{
		}
        /// <summary>
	    /// Creates a new <see cref="AccessStaffProvider"/> instance.
	    /// Uses connection string to connect to datasource.
	    /// </summary>
	    /// <param name="connectionString">The connection string to the database.</param>
	    /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public AccessStaffProvider(string connectionString, string providerInvariantName)
	    {
		    this.ConnectionString = connectionString;
		    this.ProviderInvariantName = providerInvariantName;
	    }
        #endregion

        /// <summary>
        /// 获取新插入记录的Id。
        /// </summary>
        /// <returns>新插入记录的Id。</returns>
        private long GetIdentity(OleDbTransaction trans)
        {
            var oRet = AccessHelper.ExecuteScalar(trans, "Select max(Id) From Staffs ");
            return long.Parse(oRet.ToString());
        }

        #region Overrides of StaffProvider

        /// <summary>
        /// 添加员工。
        /// </summary>
        /// <param name="obj">员工实体。</param>
        /// <returns>员工Id。</returns>
        public override long Insert(StaffInfo obj)
        {
            var sqlStatement = @"
Insert Into Staffs ([CertId],[CertTypeId],[Code],[Name],[Company],[Department],[CustomerId],[Bank],[Account]) 
Values (@CertId,@CertTypeId,@Code,@Name,@Company,@Department,@CustomerId,@Bank,@Account)
";
            var parms = new[]
                            {
                                new OleDbParameter( "@CertId", OleDbType.VarChar,20){Value = obj.CertId},
                                new OleDbParameter("@CertTypeId",OleDbType.VarChar,10){Value = obj.CertTypeId}, 
                                new OleDbParameter("@Code",OleDbType.VarChar,50){Value = obj.Code}, 
                                new OleDbParameter("@Name", OleDbType.VarWChar, 50) {Value = obj.Name},
                                new OleDbParameter("@Company",OleDbType.VarChar,50){Value = obj.Company},
                                new OleDbParameter("@Department",OleDbType.VarChar,50){Value = obj.Department},
                                new OleDbParameter("@CustomerId",OleDbType.BigInt){Value = obj.CustomerId},
                                new OleDbParameter("@Bank",OleDbType.VarChar,50){Value = obj.Bank},
                                new OleDbParameter("@Account",OleDbType.VarChar,50){Value = obj.Account}
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
        /// 更改员工。
        /// </summary>
        /// <param name="obj">员工实体。</param>
        /// <returns>bool</returns>
        public override bool Update(StaffInfo obj)
        {
            var sqlStatement = @"
Update Staffs 
Set [CertId] = @CertId
,   [CertTypeId] = @CertTypeId
,   [CustomerId] = @CustomerId
,   [Name]=@Name
,   [Code] = @Code
,   [Company] = @Company
,   [Department] = @Department
,   [Bank] = @Bank
,   [Account] = @Account
Where Id = @Id";
            var parms = new[]
                            {
                                new OleDbParameter("@Id", OleDbType.BigInt) {Value = obj.Id},
                                new OleDbParameter( "@CertId", OleDbType.VarChar,20){Value = obj.CertId},
                                new OleDbParameter("@CertTypeId",OleDbType.VarChar,10){Value = obj.CertTypeId}, 
                                new OleDbParameter("@Code",OleDbType.VarChar,50){Value = obj.Code}, 
                                new OleDbParameter("@Name", OleDbType.VarWChar, 50) {Value = obj.Name},
                                new OleDbParameter("@Company",OleDbType.VarChar,50){Value = obj.Company},
                                new OleDbParameter("@Department",OleDbType.VarChar,50){Value = obj.Department},
                                new OleDbParameter("@CustomerId",OleDbType.BigInt){Value = obj.CustomerId},
                                new OleDbParameter("@Bank",OleDbType.VarChar,50){Value = obj.Bank},
                                new OleDbParameter("@Account",OleDbType.VarChar,50){Value = obj.Account}
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
        /// 删除员工。
        /// </summary>
        /// <param name="id">员工Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(long id)
        {
            var sqlStatement = "Delete From Staffs Where Id = @Id";
            var parms = new[]
                            {
                                new OleDbParameter("@Id", OleDbType.BigInt) {Value = id}
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
        /// 获取所有员工。
        /// </summary>
        /// <returns>员工集合。</returns>
        public override List<StaffInfo> GetByCustomerId(long customerId)
        {
            var sqlStatement = "Select [Id],[CertId],[CertTypeId],[CustomerId],[Code],[Name],[Company],[Department],[Bank],[Account] From Staffs Where [CustomerId] = @CustomerId";
            var parms = new[] {new OleDbParameter("@CustomerId", OleDbType.BigInt) {Value = customerId}};

            var objs = new List<StaffInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString,sqlStatement,parms);
            while (dr.Read())
            {
                objs.Add(ConvertToObject(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取员工。
        /// </summary>
        /// <param name="id">员工Id。</param>
        /// <returns>员工实体。</returns>
        public override StaffInfo GetById(long id)
        {
            var sqlStatement = "Select [Id],[CertId],[CertTypeId],[CustomerId],[Code],[Name],[Company],[Department],[Bank],[Account] From Staffs Where [Id] = @Id";
            var parms = new[]
                {
                    new OleDbParameter("@Id", OleDbType.BigInt) {Value = id}
                };
            StaffInfo obj = null;
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToObject(dr);
                break;
            }
            dr.Close();
            return obj;
        }
        public override StaffInfo GetByCCC(long customerId, string certId, string certTypeId)
        {
            var sqlStatement =
                "Select * From Staffs Where CustomerId = @CustomerId And CertId = @CertId And CertTypeId = @CertTypeId";
            var parms = new[]
                {
                    new OleDbParameter("@CustomerId", OleDbType.BigInt) {Value = customerId},
                    new OleDbParameter("@CertId", OleDbType.VarChar, 20) {Value = certId},
                    new OleDbParameter("@CertTypeId",OleDbType.VarChar,10){Value = certTypeId}
                };
            StaffInfo obj = null;
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
