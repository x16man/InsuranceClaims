using System.Collections.Generic;
using Insurance.Data.Model;

namespace Insurance.Data.Bases
{
    public abstract class ClaimProvider:IDAL.IClaims
    {
        #region Implementation of IClaims

        /// <summary>
        /// 添加保险理赔单。
        /// </summary>
        /// <param name="obj">保险理赔单实体。</param>
        /// <returns>保险理赔单Id。</returns>
        public abstract long Insert(ClaimInfo obj);

        /// <summary>
        /// 更改保险理赔单。
        /// </summary>
        /// <param name="obj">保险理赔单实体。</param>
        /// <returns>bool</returns>
        public abstract bool Update(ClaimInfo obj);

        /// <summary>
        /// 删除保险理赔单。
        /// </summary>
        /// <param name="obj">保险理赔单实体。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(ClaimInfo obj);

        /// <summary>
        /// 删除保险理赔单。
        /// </summary>
        /// <param name="id">保险理赔单Id。</param>
        /// <returns>bool</returns>
        public abstract bool Delete(long id);

        /// <summary>
        /// 获取所有保险理赔单集合。
        /// </summary>
        /// <returns>保险理赔单集合。</returns>
        public abstract List<ClaimInfo> GetAll();

        /// <summary>
        /// 根据保险单Id获取保险理赔单集合。
        /// </summary>
        /// <param name="insuranceId">保险单Id。</param>
        /// <returns>保险理赔单集合。</returns>
        public abstract List<ClaimInfo> GetByInsuranceId(long insuranceId);

        /// <summary>
        /// 根据保险理赔单Id获取保险理赔单。
        /// </summary>
        /// <param name="id">保险理赔单Id。</param>
        /// <returns>保险理赔单。</returns>
        public abstract ClaimInfo GetById(long id);

        #endregion
    }
}
