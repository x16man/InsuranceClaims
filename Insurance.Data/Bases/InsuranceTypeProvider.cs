using System.Collections.Generic;
using Insurance.Data.Model;

namespace Insurance.Data.Bases
{
    public abstract class InsuranceTypeProvider:IDAL.IInsuranceType
    {
        #region Implementation of IInsuranceType

        /// <summary>
        /// 添加险种。
        /// </summary>
        /// <param name="obj">险种对象。</param>
        /// <returns>险种Id。</returns>
        public abstract long Insert(InsuranceTypeInfo obj);

        /// <summary>
        /// 修改险种。
        /// </summary>
        /// <param name="obj">险种对象。</param>
        /// <returns>bool</returns>
        public abstract bool Update(InsuranceTypeInfo obj);

        /// <summary>
        /// 删除险种。
        /// </summary>
        /// <param name="obj">险种对象。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(InsuranceTypeInfo obj);

        /// <summary>
        /// 删除险种。
        /// </summary>
        /// <param name="id">险种Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(long id);

        /// <summary>
        /// 获取所有险种。
        /// </summary>
        /// <returns>险种集合。</returns>
        public abstract List<InsuranceTypeInfo> GetAll();

        #endregion
    }
}
