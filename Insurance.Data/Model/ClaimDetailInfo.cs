using System;
using System.ComponentModel;

namespace Insurance.Data.Model
{
    /// <summary>
    /// 保险理赔明细记录实体。
    /// </summary>
    public class ClaimDetailInfo
    {
        #region Property
        /// <summary>
        /// 保险理赔单明细Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long Id { get; set; }

        /// <summary>
        /// 保险理赔单Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long ClaimId { get; set; }

        /// <summary>
        /// 序号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long SequenceNo { get; set; }
        /// <summary>
        /// 证件类型。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CertType { get; set; }

        /// <summary>
        /// 证件类型名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string CertTypeName { get; set; }
        /// <summary>
        /// 身份证号码。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string PersonId { get; set; }

        /// <summary>
        /// 姓名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public bool Gender { get; set; }

        /// <summary>
        /// 投保险种Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string InsuranceTypeCode { get; set; }

        /// <summary>
        /// 投保险种名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string InsuranceTypeName { get; set; }

        /// <summary>
        /// 理赔类型Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ClaimTypeId { get; set; }

        /// <summary>
        /// 理赔类型名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ClaimTypeName { get; set; }
        /// <summary>
        /// 事故日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime OccurDate { get; set; }

        /// <summary>
        /// 开户名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string AccountName { get; set; }
        /// <summary>
        /// 帐号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Account { get; set; }
        /// <summary>
        /// 银行。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string BankId { get; set; }
        /// <summary>
        /// 银行名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string BankName { get; set; }
        /// <summary>
        /// 发票张数。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long InvoiceCount { get; set; }
        /// <summary>
        /// 发票号码。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string InvoiceNo { get; set; }
        /// <summary>
        /// 医院
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string HospitalId { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string HospitalName { get; set; }
        /// <summary>
        /// 责任内金额。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal ResponsibilityAmount { get; set; }

        /// <summary>
        /// 全自费金额。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal QZFAmount { get; set; }
        /// <summary>
        /// 部分自费金额。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal BFZFAmount { get; set; }
        /// <summary>
        /// 其他扣除费用。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal QTKCAmount { get; set; }

        [Bindable(BindableSupport.Yes)]
        public decimal YBZFAmount { get; set; }

        [Bindable(BindableSupport.Yes)]
        public decimal DSFZFAmount { get; set; }

        [Bindable(BindableSupport.Yes)]
        public decimal MPEAmount { get; set; }

        [Bindable(BindableSupport.Yes)]
        public decimal PFRate { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string ClaimNo { get; set; }

        /// <summary>
        /// 理赔金额。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal ClaimAmount { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
