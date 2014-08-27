using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

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
        /// 身份证号码。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string PersonId { get; set; }

        /// <summary>
        /// 工号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string HRID { get; set; }

        /// <summary>
        /// 姓名。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 连带信息
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string RelatedPerson { get; set; }

        /// <summary>
        /// 发票张数。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long InvoiceCount { get; set; }

        /// <summary>
        /// 投保险种Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long InsuranceTypeId { get; set; }

        /// <summary>
        /// 投保险种名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string InsuranceTypeName { get; set; }

        /// <summary>
        /// 责任内金额。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal ResponsibilityAmount { get; set; }

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
