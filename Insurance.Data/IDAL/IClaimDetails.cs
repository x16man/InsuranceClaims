namespace Insurance.Data.IDAL
{
    using System.Collections.Generic;
    using Insurance.Data.Model;
    /// <summary>
    /// �������ⵥ��ϸ��¼�����ݷ���ӿڡ�
    /// </summary>
    public interface IClaimDetails
    {
        /// <summary>
        /// ��ӱ������ⵥ��ϸ��¼��
        /// </summary>
        /// <param name="obj">�������ⵥ��ϸ��¼ʵ�塣</param>
        /// <returns>�������ⵥ��ϸ��¼Id��</returns>
        long Insert(ClaimDetailInfo obj);

        /// <summary>
        /// ���ı������ⵥ��ϸ��¼
        /// </summary>
        /// <param name="obj">�������ⵥ��ϸ��¼ʵ��</param>
        /// <returns>bool</returns>
        bool Update(ClaimDetailInfo obj);

        /// <summary>
        /// ɾ���������ⵥ��ϸ��¼��
        /// </summary>
        /// <param name="obj">�������ⵥ��ϸ��¼��</param>
        /// <returns>bool</returns>
        bool Delete(ClaimDetailInfo obj);

        /// <summary>
        /// ɾ���������ⵥ��ϸ��¼��
        /// </summary>
        /// <param name="id">�������ⵥ��ϸ��¼Id��</param>
        /// <returns>bool</returns>
        bool Delete(long id);

        /// <summary>
        /// ��ȡ���б������ⵥ��ϸ��¼��
        /// </summary>
        /// <returns>�������ⵥ��ϸ��¼���ϡ�</returns>
        List<ClaimDetailInfo> GetAll();

        /// <summary>
        /// ���ݱ������ⵥId��ȡ�������ⵥ��ϸ��¼��
        /// </summary>
        /// <param name="claimId">�������ⵥId��</param>
        /// <returns>�������ⵥ��ϸ��¼���ϡ�</returns>
        List<ClaimDetailInfo> GetByClaimId(long claimId);

        /// <summary>
        /// ����Id��ȡ�������ⵥ��ϸ��¼Id��
        /// </summary>
        /// <param name="id">�������ⵥ��ϸ��¼Id��</param>
        /// <returns>�������ⵥ��ϸ��¼��</returns>
        ClaimDetailInfo GetById(long id);
    }
}