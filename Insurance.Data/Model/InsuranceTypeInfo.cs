using System.ComponentModel;

namespace Insurance.Data.Model
{
    public class InsuranceTypeInfo
    {
        #region Property
        /// <summary>
        /// 险种Id。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public long Id { get; set; }

        [Bindable(BindableSupport.Yes)]
        public string Code { get; set; }
        /// <summary>
        /// 险种名称。
        /// </summary>
        [Bindable(BindableSupport.Yes)]
        public string Name { get; set; }
        #endregion

        #region CTOR

        #endregion
    }
}
