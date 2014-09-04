namespace Insurance.Data.IDAL
{
    using System.Collections.Generic;
    using Insurance.Data.Model;
    /// <summary>
    /// �������ⵥ�����ݷ��ʽӿڡ�
    /// </summary>
    public interface IClaim
    {
        /// <summary>
        /// ��ӱ������ⵥ��
        /// </summary>
        /// <param name="obj">�������ⵥʵ�塣</param>
        /// <returns>�������ⵥId��</returns>
        long Insert(ClaimInfo obj);

        /// <summary>
        /// ���ı������ⵥ��
        /// </summary>
        /// <param name="obj">�������ⵥʵ�塣</param>
        /// <returns>bool</returns>
        bool Update(ClaimInfo obj);

        /// <summary>
        /// ɾ���������ⵥ��
        /// </summary>
        /// <param name="obj">�������ⵥʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(ClaimInfo obj);

        /// <summary>
        /// ɾ���������ⵥ��
        /// </summary>
        /// <param name="id">�������ⵥId��</param>
        /// <returns>bool</returns>
        bool Delete(long id);

        /// <summary>
        /// ��ȡ���б������ⵥ���ϡ�
        /// </summary>
        /// <returns>�������ⵥ���ϡ�</returns>
        List<ClaimInfo> GetAll();

        /// <summary>
        /// ���ݱ��յ�Id��ȡ�������ⵥ���ϡ�
        /// </summary>
        /// <param name="insuranceId">���յ�Id��</param>
        /// <returns>�������ⵥ���ϡ�</returns>
        List<ClaimInfo> GetByInsuranceId(long insuranceId);

        /// <summary>
        /// ���ݱ������ⵥId��ȡ�������ⵥ��
        /// </summary>
        /// <param name="id">�������ⵥId��</param>
        /// <returns>�������ⵥ��</returns>
        ClaimInfo GetById(long id);
    }
}