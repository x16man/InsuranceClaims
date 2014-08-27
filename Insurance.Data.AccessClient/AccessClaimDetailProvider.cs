using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using Shmzh.Components.SystemComponent;
using Insurance.Data.Bases;
using Insurance.Data.Model;

namespace Insurance.Data.AccessClient
{
    class AccessClaimDetailProvider:ClaimDetailProvider
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
        /// Creates a new <see cref="AccessClaimDetailProvider"/> instance.
        /// </summary>
        public AccessClaimDetailProvider()
        {
        }
        /// <summary>
        /// Creates a new <see cref="AccessClaimDetailProvider"/> instance.
        /// Uses connection string to connect to datasource.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
        public AccessClaimDetailProvider(string connectionString, string providerInvariantName)
        {
            this._connectionString = connectionString;
            this._providerInvariantName = providerInvariantName;
        }
        #endregion

        #region private method
        /// <summary>
        /// 将dr转变到保险理赔单明细记录实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>保险理赔单明细记录实体。</returns>
        private static ClaimDetailInfo ConvertToClaimDetailInfo(IDataRecord dr)
        {
            var obj = new ClaimDetailInfo();
            obj.Id = long.Parse(dr["Id"].ToString());
            obj.ClaimId = long.Parse(dr["ClaimId"].ToString());
            obj.SequenceNo = long.Parse(dr["SequenceNo"].ToString());
            obj.PersonId = dr["PersonId"] == DBNull.Value ? string.Empty : dr["PersonId"].ToString();
            obj.HRID = dr["HRID"] == DBNull.Value ? string.Empty : dr["HRID"].ToString();
            obj.Name = dr["Name"].ToString();
            obj.RelatedPerson = dr["RelatedPerson"] == DBNull.Value ? string.Empty : dr["RelatedPerson"].ToString();
            obj.InvoiceCount = dr["InvoiceCount"] == DBNull.Value ? 0 : long.Parse(dr["InvoiceCount"].ToString());
            obj.InsuranceTypeId = long.Parse(dr["InsuranceTypeId"].ToString());
            obj.InsuranceTypeName = dr["InsuranceTypeName"].ToString();
            obj.ResponsibilityAmount = decimal.Parse(dr["ResponsibilityAmount"].ToString());
            obj.ClaimAmount = decimal.Parse(dr["ClaimAmount"].ToString());
            obj.Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString();

            return obj;
        }

        /// <summary>
        /// 获取新插入记录的Id。
        /// </summary>
        /// <returns>新插入记录的Id。</returns>
        private long GetIdentity(OleDbTransaction trans)
        {
            var oRet = AccessHelper.ExecuteScalar(trans, "Select max(Id) From ClaimDetails ");
            return long.Parse(oRet.ToString());
        }
        #endregion

        #region Overrides of ClaimDetailProvider

        /// <summary>
        /// 添加保险理赔单明细记录。
        /// </summary>
        /// <param name="obj">保险理赔单明细记录实体。</param>
        /// <returns>保险理赔单明细记录Id。</returns>
        public override long Insert(ClaimDetailInfo obj)
        {
            var sqlStatement = @"Insert Into ClaimDetails ([ClaimId],[SequenceNo],[PersonId],[HRID],[Name],[RelatedPerson],[InvoiceCount],[InsuranceTypeId],[ResponsibilityAmount],[ClaimAmount],[Remark]) 
                                 Values (@ClaimId,@SequenceNo,@Personid,@HRID,@Name,@RelatedPerson,@InvoiceCount,@InsuranceTypeId,@ResponsibilityAmount,@ClaimAmount,@Remark)";
            var parms = new[]
                            {
                                new OleDbParameter("@ClaimId", OleDbType.BigInt) {Value = obj.ClaimId},
                                new OleDbParameter("@SequenceNo", OleDbType.BigInt) {Value = obj.SequenceNo},
                                new OleDbParameter("@PersonId",OleDbType.VarWChar,50){Value = obj.PersonId}, 
                                new OleDbParameter("@HRID",OleDbType.VarWChar,50){Value = string.IsNullOrEmpty(obj.HRID)?DBNull.Value:(object)obj.HRID}, 
                                new OleDbParameter("@Name",OleDbType.VarWChar,50){Value = obj.Name},
                                new OleDbParameter("@RelatedPerson",OleDbType.VarWChar,50){Value = string.IsNullOrEmpty(obj.RelatedPerson)?DBNull.Value:(object)obj.RelatedPerson}, 
                                new OleDbParameter("@InvoiceCount",OleDbType.BigInt){Value = obj.InvoiceCount},
                                new OleDbParameter("@InsuranceTypeId",OleDbType.BigInt){Value = obj.InsuranceTypeId}, 
                                new OleDbParameter("@ResponsibilityAmount",OleDbType.Decimal){Value = obj.ResponsibilityAmount},
                                new OleDbParameter("@ClaimAmount",OleDbType.Decimal){Value = obj.ClaimAmount},
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
        /// 更改保险理赔单明细记录
        /// </summary>
        /// <param name="obj">保险理赔单明细记录实体</param>
        /// <returns>bool</returns>
        public override bool Update(ClaimDetailInfo obj)
        {
            var sqlStatement = @"Update ClaimDetails 
                                Set [ClaimId] = @ClaimId
                                ,   [SequenceNo]=@SequenceNo
                                ,   [PersonId]=@PersonId
                                ,   [HRID] = @HRID
                                ,   [Name]=@Name
                                ,   [RelatedPerson] = @RelatedPerson
                                ,   [InvoiceCount] = @InvoiceCount
                                ,   [InsuranceTypeId] = @InsuranceTypeId
                                ,   [ResponsibilityAmount]=@ResponsibilityAmount
                                ,   [ClaimAmount]=@ClaimAmount
                                ,   [Remark]=@Remark 
                                Where Id = @Id";
            var parms = new[]
                            {
                                new OleDbParameter("@ClaimId", OleDbType.BigInt) {Value = obj.ClaimId},
                                new OleDbParameter("@SequenceNo", OleDbType.BigInt) {Value = obj.SequenceNo},
                                new OleDbParameter("@PersonId",OleDbType.VarWChar,50){Value = obj.PersonId}, 
                                new OleDbParameter("@HRID",OleDbType.VarWChar,50){Value = string.IsNullOrEmpty(obj.HRID)?DBNull.Value:(object)obj.HRID}, 
                                new OleDbParameter("@Name",OleDbType.VarWChar,50){Value = obj.Name},
                                new OleDbParameter("@RelatedPerson",OleDbType.VarWChar,50){Value = string.IsNullOrEmpty(obj.RelatedPerson)?DBNull.Value:(object)obj.RelatedPerson}, 
                                new OleDbParameter("@InvoiceCount",OleDbType.BigInt){Value = obj.InvoiceCount},
                                new OleDbParameter("@InsuranceTypeId",OleDbType.BigInt){Value = obj.InsuranceTypeId}, 
                                new OleDbParameter("@ResponsibilityAmount",OleDbType.Decimal){Value = obj.ResponsibilityAmount},
                                new OleDbParameter("@ClaimAmount",OleDbType.Decimal){Value = obj.ClaimAmount},
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
        /// 删除保险理赔单明细记录。
        /// </summary>
        /// <param name="obj">保险理赔单明细记录。</param>
        /// <returns>bool</returns>
        public override bool Delete(ClaimDetailInfo obj)
        {
            return this.Delete(obj.Id);
        }

        /// <summary>
        /// 删除保险理赔单明细记录。
        /// </summary>
        /// <param name="id">保险理赔单明细记录Id。</param>
        /// <returns>bool</returns>
        public override bool Delete(long id)
        {
            var sqlStatement = "Delete From ClaimDetails Where Id = @Id";
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
        /// 获取所有保险理赔单明细记录。
        /// </summary>
        /// <returns>保险理赔单明细记录集合。</returns>
        public override List<ClaimDetailInfo> GetAll()
        {
            var sqlStatement = @"Select A.[Id],A.[ClaimId],A.[SequenceNo],A.[PersonId],A.[HRID],A.[Name],A.[RelatedPerson],A.[InvoiceCount],A.[InsuranceTypeId],B.[Name] As InsuranceTypeName,A.[ResponsibilityAmount],A.[ClaimAmount],A.[Remark] 
                                From    ClaimDetails A,InsuranceType B 
                                Where   A.InsuranceTypeId = B.Id";
            var objs = new List<ClaimDetailInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement);
            while (dr.Read())
            {
                objs.Add(ConvertToClaimDetailInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据保险理赔单Id获取保险理赔单明细记录。
        /// </summary>
        /// <param name="claimId">保险理赔单Id。</param>
        /// <returns>保险理赔单明细记录集合。</returns>
        public override List<ClaimDetailInfo> GetByClaimId(long claimId)
        {
            var sqlStatement = @"Select A.[Id],A.[ClaimId],A.[SequenceNo],A.[PersonId],A.[HRID],A.[Name],A.[RelatedPerson],A.[InvoiceCount],A.[InsuranceTypeId],B.[Name] As InsuranceTypeName,A.[ResponsibilityAmount],A.[ClaimAmount],A.[Remark] 
                                From    ClaimDetails A, InsuranceType B
                                Where   A.ClaimId = @ClaimId And
                                        A.InsuranceTypeId = B.Id";
            var parms = new[] {new OleDbParameter("@ClaimId", OleDbType.BigInt) {Value = claimId}};
            var objs = new List<ClaimDetailInfo>();
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement,parms);
            while (dr.Read())
            {
                objs.Add(ConvertToClaimDetailInfo(dr));
            }
            dr.Close();
            return objs;
        }

        /// <summary>
        /// 根据Id获取保险理赔单明细记录Id。
        /// </summary>
        /// <param name="id">保险理赔单明细记录Id。</param>
        /// <returns>保险理赔单明细记录。</returns>
        public override ClaimDetailInfo GetById(long id)
        {
            var sqlStatement = @"Select A.[Id],A.[ClaimId],A.[SequenceNo],A.[PersonId],A.[HRID],A.[Name],A.[RelatedPerson],A.[InvoiceCount],A.[InsuranceTypeId],B.[Name] As InsuranceTypeName,A.[ResponsibilityAmount],A.[ClaimAmount],A.[Remark] 
                                From    ClaimDetails A,InsuranceType B
                                Where   A.ClaimId = @ClaimId And
                                        A.InsuranceTypeId = B.Id";
            var parms = new[] { new OleDbParameter("@ClaimId", OleDbType.BigInt) { Value = id } };
            ClaimDetailInfo obj = null;
            var dr = AccessHelper.ExecuteReader(this.ConnectionString, sqlStatement, parms);
            while (dr.Read())
            {
                obj = ConvertToClaimDetailInfo(dr);
                break;
            }
            dr.Close();
            return obj;
        }

        #endregion
    }
}
