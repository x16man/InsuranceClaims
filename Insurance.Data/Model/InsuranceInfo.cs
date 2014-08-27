using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Data.Model
{
    /// <summary>
    /// 保险单实体。
    /// </summary>
    public class InsuranceInfo
    {
        #region
        /// <summary>
        /// 保险单Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long Id { get; set; }

        /// <summary>
        /// 保险单号。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }

        /// <summary>
        /// 保险客户Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long CustomerId { get; set; }

        /// <summary>
        /// 保险单备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion
    }
}
