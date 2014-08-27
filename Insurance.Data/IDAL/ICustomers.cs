namespace Insurance.Data.IDAL
{
    using System.Collections.Generic;
    using Insurance.Data.Model;
    /// <summary>
    /// 客户数据访问接口。
    /// </summary>
    public interface ICustomers
    {
        /// <summary>
        /// 添加客户。
        /// </summary>
        /// <param name="obj">客户实体。</param>
        /// <returns>客户Id。</returns>
        long Insert(CustomerInfo obj);

        /// <summary>
        /// 更改客户。
        /// </summary>
        /// <param name="obj">客户实体。</param>
        /// <returns>bool</returns>
        bool Update(CustomerInfo obj);

        /// <summary>
        /// 删除客户。
        /// </summary>
        /// <param name="obj">客户实体。</param>
        /// <returns>bool</returns>
        bool Delete(CustomerInfo obj);

        /// <summary>
        /// 删除客户。
        /// </summary>
        /// <param name="id">客户Id。</param>
        /// <returns>bool</returns>
        bool Delete(long id);

        /// <summary>
        /// 获取所有客户。
        /// </summary>
        /// <returns>客户集合。</returns>
        List<CustomerInfo> GetAll();

        /// <summary>
        /// 根据Id获取客户。
        /// </summary>
        /// <param name="id">客户Id。</param>
        /// <returns>客户实体。</returns>
        CustomerInfo GetById(long id);
    }
}