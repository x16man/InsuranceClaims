using System;
using System.Collections.Generic;
using System.Data;
using Insurance.Data.Model;

namespace Insurance.Data.Bases
{
    public abstract class StaffProvider:IDAL.IStaff
    {
        #region protected method
        protected  StaffInfo ConvertToObject(IDataRecord dr)
        {
            var obj = new StaffInfo();
            obj.Id = long.Parse(dr["Id"].ToString());

            obj.CertId = dr["CertId"].ToString();
            obj.CertTypeId = dr["CertTypeId"].ToString();
            obj.CustomerId = long.Parse(dr["CustomerId"].ToString());

            obj.Code = dr["Code"].ToString();
            obj.Name = dr["Name"].ToString();
            obj.Company = dr["Company"] == DBNull.Value ? string.Empty : dr["Company"].ToString();
            obj.Department = dr["Department"] == DBNull.Value ? string.Empty : dr["Department"].ToString();
            obj.Bank = dr["Bank"] == DBNull.Value ? string.Empty : dr["Bank"].ToString();
            obj.Account = dr["Account"] == DBNull.Value ? string.Empty : dr["Account"].ToString();
            return obj;
        }
        #endregion

        #region Implementation of IStaff

        public abstract long Insert(StaffInfo obj);
        public abstract bool Update(StaffInfo obj);
        public abstract bool Delete(long id);
        public abstract StaffInfo GetById(long id);
        
        public  abstract StaffInfo GetByCCC(long customerId, string certId, string certTypeId);
        public abstract List<StaffInfo> GetByCustomerId(long customerId);

        #endregion
    }
}
