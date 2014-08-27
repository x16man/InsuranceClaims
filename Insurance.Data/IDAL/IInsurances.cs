namespace Insurance.Data.IDAL
{
    using System.Collections.Generic;
    using Insurance.Data.Model;
    /// <summary>
    /// 保险单数据访问接口。
    /// </summary>
    public interface IInsurances
    {
        /// <summary>
        /// 添加保险单。
        /// </summary>
        /// <param name="obj">保险单实体。</param>
        /// <returns>保险单Id。</returns>
        long Insert(InsuranceInfo obj);

        /// <summary>
        /// 更改保险单。
        /// </summary>
        /// <param name="obj">保险单实体。</param>
        /// <returns>bool</returns>
        bool Update(InsuranceInfo obj);

        /// <summary>
        /// 删除保险单。
        /// </summary>
        /// <param name="obj">保险单实体。</param>
        /// <returns>bool</returns>
        bool Delete(InsuranceInfo obj);

        /// <summary>
        /// 删除保险单。
        /// </summary>
        /// <param name="id">保险单Id。</param>
        /// <returns>bool</returns>
        bool Delete(long id);

        /// <summary>
        /// 获取所有保险单。
        /// </summary>
        /// <returns>保险单集合。</returns>
        List<InsuranceInfo> GetAll();

        /// <summary>
        /// 根据客户Id获取保险单集合。
        /// </summary>
        /// <param name="customerId">客户Id。</param>
        /// <returns>保险单集合。</returns>
        List<InsuranceInfo> GetByCustomerId(long customerId);

        /// <summary>
        /// 根据保险单Id获取保险单。
        /// </summary>
        /// <param name="id">保险单Id。</param>
        /// <returns>保险单实体。</returns>
        InsuranceInfo GetById(long id);

    }
}