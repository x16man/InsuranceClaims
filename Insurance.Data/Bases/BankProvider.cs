using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Insurance.Data.Model;

namespace Insurance.Data.Bases
{
    public abstract class BankProvider:IDAL.IBank
    {
        #region protected method
        protected  BankInfo ConvertToObject(IDataRecord dr)
        {
            var obj = new BankInfo();
            obj.Id = dr["Id"].ToString();
            obj.OldId = obj.Id;
            obj.Name = dr["Name"].ToString();

            return obj;
        }
        #endregion

        #region Implementation of IBank

        public abstract bool Insert(BankInfo obj);
        public abstract bool Update(BankInfo obj);
        public abstract bool Delete(string id);
        public abstract BankInfo GetById(string id);
        public abstract List<BankInfo> GetAll();

        #endregion
    }
}
