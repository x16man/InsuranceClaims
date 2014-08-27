using System.Collections.Generic;
using Insurance.Data.Model;

namespace Insurance.Data.IDAL
{
    public interface IInsuranceType
    {
        /// <summary>
        /// 添加险种。
        /// </summary>
        /// <param name="obj">险种对象。</param>
        /// <returns>险种Id。</returns>
        long Insert(InsuranceTypeInfo obj);
        /// <summary>
        /// 修改险种。
        /// </summary>
        /// <param name="obj">险种对象。</param>
        /// <returns>bool</returns>
        bool Update(InsuranceTypeInfo obj);
        /// <summary>
        /// 删除险种。
        /// </summary>
        /// <param name="obj">险种对象。</param>
        /// <returns>bool</returns>
        bool Delete(InsuranceTypeInfo obj);
        /// <summary>
        /// 删除险种。
        /// </summary>
        /// <param name="id">险种Id。</param>
        /// <returns>bool</returns>
        bool Delete(long id);
        /// <summary>
        /// 获取所有险种。
        /// </summary>
        /// <returns>险种集合。</returns>
        List<InsuranceTypeInfo> GetAll();
    }
}