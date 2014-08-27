namespace Insurance.Data.IDAL
{
    using System.Collections.Generic;
    using Insurance.Data.Model;
    /// <summary>
    /// ���յ����ݷ��ʽӿڡ�
    /// </summary>
    public interface IInsurances
    {
        /// <summary>
        /// ��ӱ��յ���
        /// </summary>
        /// <param name="obj">���յ�ʵ�塣</param>
        /// <returns>���յ�Id��</returns>
        long Insert(InsuranceInfo obj);

        /// <summary>
        /// ���ı��յ���
        /// </summary>
        /// <param name="obj">���յ�ʵ�塣</param>
        /// <returns>bool</returns>
        bool Update(InsuranceInfo obj);

        /// <summary>
        /// ɾ�����յ���
        /// </summary>
        /// <param name="obj">���յ�ʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(InsuranceInfo obj);

        /// <summary>
        /// ɾ�����յ���
        /// </summary>
        /// <param name="id">���յ�Id��</param>
        /// <returns>bool</returns>
        bool Delete(long id);

        /// <summary>
        /// ��ȡ���б��յ���
        /// </summary>
        /// <returns>���յ����ϡ�</returns>
        List<InsuranceInfo> GetAll();

        /// <summary>
        /// ���ݿͻ�Id��ȡ���յ����ϡ�
        /// </summary>
        /// <param name="customerId">�ͻ�Id��</param>
        /// <returns>���յ����ϡ�</returns>
        List<InsuranceInfo> GetByCustomerId(long customerId);

        /// <summary>
        /// ���ݱ��յ�Id��ȡ���յ���
        /// </summary>
        /// <param name="id">���յ�Id��</param>
        /// <returns>���յ�ʵ�塣</returns>
        InsuranceInfo GetById(long id);

    }
}