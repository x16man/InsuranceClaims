using System.Collections.Generic;
using Insurance.Data.Model;

namespace Insurance.Data.IDAL
{
    public interface IInsuranceType
    {
        /// <summary>
        /// ������֡�
        /// </summary>
        /// <param name="obj">���ֶ���</param>
        /// <returns>����Id��</returns>
        long Insert(InsuranceTypeInfo obj);
        /// <summary>
        /// �޸����֡�
        /// </summary>
        /// <param name="obj">���ֶ���</param>
        /// <returns>bool</returns>
        bool Update(InsuranceTypeInfo obj);
        /// <summary>
        /// ɾ�����֡�
        /// </summary>
        /// <param name="obj">���ֶ���</param>
        /// <returns>bool</returns>
        bool Delete(InsuranceTypeInfo obj);
        /// <summary>
        /// ɾ�����֡�
        /// </summary>
        /// <param name="id">����Id��</param>
        /// <returns>bool</returns>
        bool Delete(long id);
        /// <summary>
        /// ��ȡ�������֡�
        /// </summary>
        /// <returns>���ּ��ϡ�</returns>
        List<InsuranceTypeInfo> GetAll();
    }
}