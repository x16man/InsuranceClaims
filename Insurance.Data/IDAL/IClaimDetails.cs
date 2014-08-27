namespace Insurance.Data.IDAL
{
    using System.Collections.Generic;
    using Insurance.Data.Model;
    /// <summary>
    /// 保险理赔单明细记录的数据服务接口。
    /// </summary>
    public interface IClaimDetails
    {
        /// <summary>
        /// 添加保险理赔单明细记录。
        /// </summary>
        /// <param name="obj">保险理赔单明细记录实体。</param>
        /// <returns>保险理赔单明细记录Id。</returns>
        long Insert(ClaimDetailInfo obj);

        /// <summary>
        /// 更改保险理赔单明细记录
        /// </summary>
        /// <param name="obj">保险理赔单明细记录实体</param>
        /// <returns>bool</returns>
        bool Update(ClaimDetailInfo obj);

        /// <summary>
        /// 删除保险理赔单明细记录。
        /// </summary>
        /// <param name="obj">保险理赔单明细记录。</param>
        /// <returns>bool</returns>
        bool Delete(ClaimDetailInfo obj);

        /// <summary>
        /// 删除保险理赔单明细记录。
        /// </summary>
        /// <param name="id">保险理赔单明细记录Id。</param>
        /// <returns>bool</returns>
        bool Delete(long id);

        /// <summary>
        /// 获取所有保险理赔单明细记录。
        /// </summary>
        /// <returns>保险理赔单明细记录集合。</returns>
        List<ClaimDetailInfo> GetAll();

        /// <summary>
        /// 根据保险理赔单Id获取保险理赔单明细记录。
        /// </summary>
        /// <param name="claimId">保险理赔单Id。</param>
        /// <returns>保险理赔单明细记录集合。</returns>
        List<ClaimDetailInfo> GetByClaimId(long claimId);

        /// <summary>
        /// 根据Id获取保险理赔单明细记录Id。
        /// </summary>
        /// <param name="id">保险理赔单明细记录Id。</param>
        /// <returns>保险理赔单明细记录。</returns>
        ClaimDetailInfo GetById(long id);
    }
}