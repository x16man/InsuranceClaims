using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Data.Model
{
    /// <summary>
    /// 客户信息实体。
    /// </summary>
    public class CustomerInfo
    {
        #region Property
        /// <summary>
        /// 客户Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long Id { get; set; }

        /// <summary>
        /// 客户分类Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long CategoryId { get; set; }

        /// <summary>
        /// 客户名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }

        /// <summary>
        /// 客户地址。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Address { get; set; }
        /// <summary>
        /// 客户备注。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Remark { get; set; }
        #endregion


    }
}
