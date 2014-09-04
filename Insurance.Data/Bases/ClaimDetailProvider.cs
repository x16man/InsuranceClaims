using System;
using System.Collections.Generic;
using System.Data;
using Insurance.Data.Model;

namespace Insurance.Data.Bases
{
    public abstract class ClaimDetailProvider:IDAL.IClaimDetail
    {
        #region Protected Method
        /// <summary>
        /// 将dr转变到保险理赔单明细记录实体。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>保险理赔单明细记录实体。</returns>
        protected static ClaimDetailInfo ConvertToClaimDetailInfo(IDataRecord dr)
        {
            var obj = new ClaimDetailInfo();
            obj.Id = long.Parse(dr["Id"].ToString());
            obj.ClaimId = long.Parse(dr["ClaimId"].ToString());
            obj.SequenceNo = long.Parse(dr["SequenceNo"].ToString());
            obj.CertType = dr["CertType"] == DBNull.Value ? string.Empty : dr["CertType"].ToString();
            obj.CertTypeName = dr["CertTypeName"] == DBNull.Value ? string.Empty : dr["CertTypeName"].ToString();
            obj.PersonId = dr["PersonId"] == DBNull.Value ? string.Empty : dr["PersonId"].ToString();
            obj.Name = dr["Name"].ToString();
            obj.Gender = dr["Gender"] == DBNull.Value || bool.Parse(dr["Gender"].ToString());
            obj.InsuranceTypeCode = dr["InsuranceTypeCode"].ToString();
            obj.InsuranceTypeName = dr["InsuranceTypeName"].ToString();
            obj.ClaimTypeId = dr["ClaimTypeId"].ToString();
            obj.ClaimTypeName = dr["ClaimTypeName"].ToString();

            obj.OccurDate = dr["OccurDate"] == DBNull.Value
                                ? DateTime.MinValue
                                : DateTime.Parse(dr["OccurDate"].ToString());
            obj.AccountName = dr["AccountName"] == DBNull.Value ? string.Empty : dr["AccountName"].ToString();
            obj.Account = dr["Account"] == DBNull.Value ? string.Empty : dr["Account"].ToString();
            obj.BankId = dr["BankId"] == DBNull.Value ? string.Empty : dr["BankId"].ToString();
            obj.BankName = dr["BankName"] == DBNull.Value ? string.Empty : dr["BankName"].ToString();
            obj.InvoiceNo = dr["InvoiceNo"] == DBNull.Value ? string.Empty : dr["InvoiceNo"].ToString();
            obj.InvoiceCount = dr["InvoiceCount"] == DBNull.Value ? 0 : long.Parse(dr["InvoiceCount"].ToString());
            obj.HospitalId = dr["HospitalId"] == DBNull.Value ? string.Empty : dr["HospitalId"].ToString();
            obj.HospitalName = dr["HospitalName"] == DBNull.Value ? string.Empty : dr["HospitalName"].ToString();

            obj.ResponsibilityAmount = decimal.Parse(dr["ResponsibilityAmount"].ToString());
            obj.QZFAmount = dr["QZFAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["QZFAmount"].ToString());
            obj.BFZFAmount = dr["BFZFAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["BFZFAmount"].ToString());
            obj.QTKCAmount = dr["QTKCAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["QTKCAmount"].ToString());
            obj.YBZFAmount = dr["YBZFAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["YBZFAmount"].ToString());
            obj.DSFZFAmount = dr["DSFZFAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["DSFZFAmount"].ToString());
            obj.MPEAmount = dr["MPEAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["MPEAmount"].ToString());
            obj.PFRate = dr["PFRate"] == DBNull.Value ? 1 : decimal.Parse(dr["PFRate"].ToString());
            obj.ClaimNo = dr["ClaimNo"] == DBNull.Value ? string.Empty : dr["ClaimNo"].ToString();


            obj.ClaimAmount = decimal.Parse(dr["ClaimAmount"].ToString());
            obj.Remark = dr["Remark"] == DBNull.Value ? string.Empty : dr["Remark"].ToString();

            return obj;
        }
        #endregion
        #region Implementation of IClaimDetails

        /// <summary>
        /// 添加保险理赔单明细记录。
        /// </summary>
        /// <param name="obj">保险理赔单明细记录实体。</param>
        /// <returns>保险理赔单明细记录Id。</returns>
        public abstract long Insert(ClaimDetailInfo obj);

        /// <summary>
        /// 更改保险理赔单明细记录
        /// </summary>
        /// <param name="obj">保险理赔单明细记录实体</param>
        /// <returns>bool</returns>
        public abstract bool Update(ClaimDetailInfo obj);

        /// <summary>
        /// 删除保险理赔单明细记录。
        /// </summary>
        /// <param name="obj">保险理赔单明细记录。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(ClaimDetailInfo obj);

        /// <summary>
        /// 删除保险理赔单明细记录。
        /// </summary>
        /// <param name="id">保险理赔单明细记录Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(long id);

        /// <summary>
        /// 获取所有保险理赔单明细记录。
        /// </summary>
        /// <returns>保险理赔单明细记录集合。</returns>
        public abstract List<ClaimDetailInfo> GetAll();

        /// <summary>
        /// 根据保险理赔单Id获取保险理赔单明细记录。
        /// </summary>
        /// <param name="claimId">保险理赔单Id。</param>
        /// <returns>保险理赔单明细记录集合。</returns>
        public abstract List<ClaimDetailInfo> GetByClaimId(long claimId);

        /// <summary>
        /// 根据Id获取保险理赔单明细记录Id。
        /// </summary>
        /// <param name="id">保险理赔单明细记录Id。</param>
        /// <returns>保险理赔单明细记录。</returns>
        public abstract ClaimDetailInfo GetById(long id);

        #endregion
    }
}
