using System;
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
            var sqlStatement = @"
Insert Into ClaimDetails (
    [ClaimId]
,   [SequenceNo]
,   [CertType]
,   [PersonId]
,   [Name]
,   [Gender]
,   [InsuranceTypeCode]
,   [ClaimTypeId]
,   OccurDate
,   AccountName
,   Account
,   BankId
,   InvoiceNo
,   [InvoiceCount]
,   HospitalId
,   [ResponsibilityAmount]
,   QZFAmount
,   BFZFAmount
,   QTKCAmount
,   YBZFAmount
,   DSFZFAmount
,   MPEAmount
,   PFRate
,   [ClaimAmount]
,   [Remark]
,   ClaimNo) 
Values (
    @ClaimId
,   @SequenceNo
,   @CertType
,   @Personid
,   @Name
,   @Gender
,   @InsuranceTypeCode
,   @ClaimTypeId
,   @OccurDate
,   @AccountName
,   @Account
,   @BankId
,   @InvoiceNo
,   @InvoiceCount
,   @HospitalId
,   @ResponsibilityAmount
,   @QZFAmount
,   @BFZFAmount
,   @QTKCAmount
,   @YBZFAmount
,   @DSFZFAmount
,   @MPEAmount
,   @PFRate
,   @ClaimAmount
,   @Remark
,   @ClaimNo
)";
            var parms = new[]
                            {
                                new OleDbParameter("@ClaimId", OleDbType.BigInt) {Value = obj.ClaimId},
                                new OleDbParameter("@SequenceNo", OleDbType.BigInt) {Value = obj.SequenceNo},
                                new OleDbParameter("@CertType",OleDbType.VarChar,10){Value = obj.CertType}, 
                                new OleDbParameter("@PersonId",OleDbType.VarWChar,50){Value = obj.PersonId}, 
                                new OleDbParameter("@Name",OleDbType.VarWChar,50){Value = obj.Name},
                                new OleDbParameter("@Gender",OleDbType.Boolean){Value = obj.Gender}, 
                                new OleDbParameter("@InsuranceTypeCode",OleDbType.VarChar,10){Value = obj.InsuranceTypeCode}, 
                                new OleDbParameter("@ClaimTypeId",OleDbType.VarChar,10){Value = obj.ClaimTypeId}, 
                                new OleDbParameter("@OccurDate",OleDbType.Date){Value = obj.OccurDate==DateTime.MinValue?DBNull.Value:(object)obj.OccurDate},
                                new OleDbParameter("@AccountName",OleDbType.VarChar,50){Value = obj.AccountName},
                                new OleDbParameter("@Account",OleDbType.VarChar,50){Value = obj.Account},
                                new OleDbParameter("@BankId",OleDbType.VarChar,10){Value = obj.BankId},
                                new OleDbParameter("@InvoiceNo",OleDbType.VarChar,50){Value = obj.InvoiceNo}, 
                                new OleDbParameter("@InvoiceCount",OleDbType.BigInt){Value = obj.InvoiceCount},
                                new OleDbParameter("@HospitalId",OleDbType.VarChar,10){Value = obj.HospitalId},
                                new OleDbParameter("@ResponsibilityAmount",OleDbType.Decimal){Value = obj.ResponsibilityAmount},
                                new OleDbParameter("@QZFAmount",OleDbType.Decimal){Value = obj.QZFAmount},
                                new OleDbParameter("@BFZFAmount",OleDbType.Decimal){Value = obj.BFZFAmount},
                                new OleDbParameter("@QTKCAmount",OleDbType.Decimal){Value = obj.QTKCAmount},
                                new OleDbParameter("@YBZFAmount",OleDbType.Decimal){Value = obj.YBZFAmount},
                                new OleDbParameter("@DSFZFAmount",OleDbType.Decimal){Value = obj.DSFZFAmount},
                                new OleDbParameter("@MPEAmount",OleDbType.Decimal){Value = obj.MPEAmount},
                                new OleDbParameter("@PFRate",OleDbType.Numeric){Value = obj.PFRate}, 
                                new OleDbParameter("@ClaimAmount",OleDbType.Decimal){Value = obj.ClaimAmount},
                                new OleDbParameter("@Remark",OleDbType.VarWChar,255){Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
                                new OleDbParameter("@ClaimNo",OleDbType.VarChar,50){Value = obj.ClaimNo} 
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
        var sqlStatement = @"
Update ClaimDetails 
Set [ClaimId] = @ClaimId
,   [SequenceNo]=@SequenceNo
,   [CertType]=@CertType
,   [PersonId]=@PersonId
,   [Name]=@Name
,   [Gender] = @Gender
,   [InsuranceTypeCode] = @InsuranceTypeCode
,   [ClaimTypeId] = @ClaimTypeId
,   [OccurDate] = @Occurdate
,   [AccountName] = @AccountName
,   [Account] = @Account
,   [BankId] = @BankId
,   [InvoiceNo] = @InvoiceNo
,   [InvoiceCount] = @InvoiceCount
,   [HospitalId] = @HospitalId
,   [ResponsibilityAmount]=@ResponsibilityAmount
,   [QZFAmount] = @QZFAmount
,   [BFZFAmount] = @BFZFAmount
,   [QTKCAmount] = @QTKCAmount
,   [YBZFAmount] = @YBZFAmount
,   [DSFZFAmount] = @DSFZFAmount
,   [MPEAmount] = @MPEAmount
,   [PFRate] = @PFRate
,   [ClaimAmount]=@ClaimAmount
,   [Remark]=@Remark 
,   [ClaimNo] = @ClaimNo
Where Id = @Id";
            var parms = new[]
                            {
                                new OleDbParameter("@ClaimId", OleDbType.BigInt) {Value = obj.ClaimId},
                                new OleDbParameter("@SequenceNo", OleDbType.BigInt) {Value = obj.SequenceNo},
                                new OleDbParameter("@CertType",OleDbType.VarChar,10){Value = obj.CertType}, 
                                new OleDbParameter("@PersonId",OleDbType.VarWChar,50){Value = obj.PersonId}, 
                                new OleDbParameter("@Name",OleDbType.VarWChar,50){Value = obj.Name},
                                new OleDbParameter("@Gender",OleDbType.Boolean){Value = obj.Gender}, 
                                new OleDbParameter("@InsuranceTypeCode",OleDbType.VarChar,10){Value = obj.InsuranceTypeCode}, 
                                new OleDbParameter("@ClaimTypeId",OleDbType.VarChar,10){Value = obj.ClaimTypeId}, 
                                new OleDbParameter("@OccurDate",OleDbType.Date){Value = obj.OccurDate==DateTime.MinValue?DBNull.Value:(object)obj.OccurDate},
                                new OleDbParameter("@AccountName",OleDbType.VarChar,50){Value = obj.AccountName},
                                new OleDbParameter("@Account",OleDbType.VarChar,50){Value = obj.Account},
                                new OleDbParameter("@BankId",OleDbType.VarChar,10){Value = obj.BankId},
                                new OleDbParameter("@InvoiceNo",OleDbType.VarChar,50){Value = obj.InvoiceNo}, 
                                new OleDbParameter("@InvoiceCount",OleDbType.BigInt){Value = obj.InvoiceCount},
                                new OleDbParameter("@HospitalId",OleDbType.VarChar,10){Value = obj.HospitalId},
                                new OleDbParameter("@ResponsibilityAmount",OleDbType.Decimal){Value = obj.ResponsibilityAmount},
                                new OleDbParameter("@QZFAmount",OleDbType.Decimal){Value = obj.QZFAmount},
                                new OleDbParameter("@BFZFAmount",OleDbType.Decimal){Value = obj.BFZFAmount},
                                new OleDbParameter("@QTKCAmount",OleDbType.Decimal){Value = obj.QTKCAmount},
                                new OleDbParameter("@YBZFAmount",OleDbType.Decimal){Value = obj.YBZFAmount},
                                new OleDbParameter("@DSFZFAmount",OleDbType.Decimal){Value = obj.DSFZFAmount},
                                new OleDbParameter("@MPEAmount",OleDbType.Decimal){Value = obj.MPEAmount},
                                new OleDbParameter("@PFRate",OleDbType.Numeric){Value = obj.PFRate}, 
                                new OleDbParameter("@ClaimAmount",OleDbType.Decimal){Value = obj.ClaimAmount},
                                new OleDbParameter("@Remark",OleDbType.VarWChar,255){Value = string.IsNullOrEmpty(obj.Remark)?DBNull.Value:(object)obj.Remark},
                                new OleDbParameter("@ClaimNo",OleDbType.VarChar,50){Value = obj.ClaimNo}  
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
                                new OleDbParameter("@Id",OleDbType.BigInt){Value = id} 
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
            var sqlStatement = @"
Select  A.[Id]
,       A.[ClaimId]
,       A.[SequenceNo]
,       A.CertType
,       C.Name AS CertTypeName
,       A.[PersonId]
,       A.[Name]
,       A.[Gender]
,       A.[InsuranceTypeCode]
,       B.[Name] As InsuranceTypeName
,       A.[ClaimTypeId]
,       F.[Name] As ClaimTypeName
,       A.OccurDate
,       A.AccountName
,       A.Account
,       A.BankId
,       D.Name As BankName
,       A.InvoiceNo
,       A.[InvoiceCount]
,       A.HospitalId
,       E.Name as HospitalName
,       A.[ResponsibilityAmount]
,       A.QZFAmount
,       A.BFZFAmount
,       A.QTKCAmount
,       A.YBZFAmount
,       A.DSFZFAmount
,       A.MPEAmount
,       A.PFRate
,       A.[ClaimAmount]
,       A.[Remark]
,       A.ClaimNo 
From    ClaimDetails A,InsuranceType B,CertTypes C,Banks D,Hospitals E,ClaimTypes F
Where   A.InsuranceTypeCode = B.Code And
        A.CertType = C.Id And
        A.BankId = D.Id And
        A.HospitalId = E.Id And
        A.ClaimTypeId = F.Id";
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
            var sqlStatement = @"
Select  A.[Id]
,       A.[ClaimId]
,       A.[SequenceNo]
,       A.CertType
,       C.Name AS CertTypeName
,       A.[PersonId]
,       A.[Name]
,       A.[Gender]
,       A.[InsuranceTypeCode]
,       B.[Name] As InsuranceTypeName
,       A.[ClaimTypeId]
,       F.[Name] As ClaimTypeName

,       A.OccurDate
,       A.AccountName
,       A.Account
,       A.BankId
,       D.Name As BankName
,       A.InvoiceNo
,       A.[InvoiceCount]
,       A.HospitalId
,       E.Name as HospitalName
,       A.[ResponsibilityAmount]
,       A.QZFAmount
,       A.BFZFAmount
,       A.QTKCAmount
,       A.YBZFAmount
,       A.DSFZFAmount
,       A.MPEAmount
,       A.PFRate
,       A.[ClaimAmount]
,       A.[Remark]
,       A.ClaimNo 
From    ClaimDetails A,InsuranceType B,CertTypes C,Banks D,Hospitals E,ClaimTypes F
Where   A.InsuranceTypeCode = B.Code And
        A.CertType = C.Id And
        A.BankId = D.Id And
        A.HospitalId = E.Id And
        A.ClaimTypeId = F.Id And
        A.ClaimId = @ClaimId";
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
            var sqlStatement = @"
Select  A.[Id]
,       A.[ClaimId]
,       A.[SequenceNo]
,       A.CertType
,       C.Name AS CertTypeName
,       A.[PersonId]
,       A.[Name]
,       A.[Gender]
,       A.[InsuranceTypeCode]
,       B.[Name] As InsuranceTypeName
,       A.[ClaimTypeId]
,       F.[Name] As ClaimTypeName

,       A.OccurDate
,       A.AccountName
,       A.Account
,       A.BankId
,       D.Name As BankName
,       A.InvoiceNo
,       A.[InvoiceCount]
,       A.HospitalId
,       E.Name as HospitalName
,       A.[ResponsibilityAmount]
,       A.QZFAmount
,       A.BFZFAmount
,       A.QTKCAmount
,       A.YBZFAmount
,       A.DSFZFAmount
,       A.MPEAmount
,       A.PFRate
,       A.[ClaimAmount]
,       A.[Remark]
,       A.ClaimNo 
From    ClaimDetails A,InsuranceType B,CertTypes C,Banks D,Hospitals E,ClaimTypes F
Where   A.InsuranceTypeCode = B.Code And
        A.CertType = C.Id And
        A.BankId = D.Id And
        A.HospitalId = E.Id And
        A.ClaimTypeId = F.Id
        A.Id = @Id";
            var parms = new[] { new OleDbParameter("@Id", OleDbType.BigInt) { Value = id } };
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
