using System;
using System.ComponentModel;

namespace Insurance.Data.Model
{
    /// <summary>
    /// 保险理赔单实体。
    /// </summary>
    public class ClaimInfo
    {
        #region Property
        /// <summary>
        /// 保险理赔单Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long Id { get; set; }

        /// <summary>
        /// 保险单号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long InsuranceId { get; set; }

        /// <summary>
        /// 保险理赔单号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ClaimNo { get; set; }

        /// <summary>
        /// 保险理赔单名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string ClaimName { get; set; }

        /// <summary>
        /// 保险理赔日期。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public DateTime ClaimDate { get; set; }

        /// <summary>
        /// 保险理赔单总金额。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public decimal SubTotal { get; set; }

        /// <summary>
        /// 保险理赔单备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
