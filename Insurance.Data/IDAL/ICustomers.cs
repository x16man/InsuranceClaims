namespace Insurance.Data.IDAL
{
    using System.Collections.Generic;
    using Insurance.Data.Model;
    /// <summary>
    /// �ͻ����ݷ��ʽӿڡ�
    /// </summary>
    public interface ICustomers
    {
        /// <summary>
        /// ��ӿͻ���
        /// </summary>
        /// <param name="obj">�ͻ�ʵ�塣</param>
        /// <returns>�ͻ�Id��</returns>
        long Insert(CustomerInfo obj);

        /// <summary>
        /// ���Ŀͻ���
        /// </summary>
        /// <param name="obj">�ͻ�ʵ�塣</param>
        /// <returns>bool</returns>
        bool Update(CustomerInfo obj);

        /// <summary>
        /// ɾ���ͻ���
        /// </summary>
        /// <param name="obj">�ͻ�ʵ�塣</param>
        /// <returns>bool</returns>
        bool Delete(CustomerInfo obj);

        /// <summary>
        /// ɾ���ͻ���
        /// </summary>
        /// <param name="id">�ͻ�Id��</param>
        /// <returns>bool</returns>
        bool Delete(long id);

        /// <summary>
        /// ��ȡ���пͻ���
        /// </summary>
        /// <returns>�ͻ����ϡ�</returns>
        List<CustomerInfo> GetAll();

        /// <summary>
        /// ����Id��ȡ�ͻ���
        /// </summary>
        /// <param name="id">�ͻ�Id��</param>
        /// <returns>�ͻ�ʵ�塣</returns>
        CustomerInfo GetById(long id);
    }
}