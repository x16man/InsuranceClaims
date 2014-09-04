using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Insurance.Data.Model;

namespace Insurance.Data.Bases
{
    public abstract class CertTypeProvider:IDAL.ICertType
    {
        #region protected method
        protected  CertTypeInfo ConvertToObject(IDataRecord dr)
        {
            var obj = new CertTypeInfo();
            obj.Id = dr["Id"].ToString();
            obj.OldId = obj.Id;
            obj.Name = dr["Name"].ToString();

            return obj;
        }
        #endregion

        #region Implementation of ICertType

        public abstract bool Insert(CertTypeInfo obj);
        public abstract bool Update(CertTypeInfo obj);
        public abstract bool Delete(string id);
        public abstract CertTypeInfo GetById(string id);
        public abstract List<CertTypeInfo> GetAll();

        #endregion
    }
}
