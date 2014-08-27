using System.Collections.Generic;
using Insurance.Data.Model;

namespace Insurance.Data.Bases
{
    public abstract class CustomerProvider :IDAL.ICustomers
    {
        #region Implementation of ICustomers

        /// <summary>
        /// 添加客户。
        /// </summary>
        /// <param name="obj">客户实体。</param>
        /// <returns>客户Id。</returns>
        public abstract long Insert(CustomerInfo obj);

        /// <summary>
        /// 更改客户。
        /// </summary>
        /// <param name="obj">客户实体。</param>
        /// <returns>bool</returns>
        public abstract bool Update(CustomerInfo obj);

        /// <summary>
        /// 删除客户。
        /// </summary>
        /// <param name="obj">客户实体。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(CustomerInfo obj);

        /// <summary>
        /// 删除客户。
        /// </summary>
        /// <param name="id">客户Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(long id);

        /// <summary>
        /// 获取所有客户。
        /// </summary>
        /// <returns>客户集合。</returns>
        public abstract List<CustomerInfo> GetAll();

        /// <summary>
        /// 根据Id获取客户。
        /// </summary>
        /// <param name="id">客户Id。</param>
        /// <returns>客户实体。</returns>
        public abstract CustomerInfo GetById(long id);

        #endregion
    }
}
