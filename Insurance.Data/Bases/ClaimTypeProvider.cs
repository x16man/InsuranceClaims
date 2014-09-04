using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Insurance.Data.Model;

namespace Insurance.Data.Bases
{
    public abstract class ClaimTypeProvider:IDAL.IClaimType
    {
        #region protected method
        protected  ClaimTypeInfo ConvertToObject(IDataRecord dr)
        {
            var obj = new ClaimTypeInfo();
            obj.Id = dr["Id"].ToString();
            obj.OldId = obj.Id;
            obj.Name = dr["Name"].ToString();

            return obj;
        }
        #endregion

        #region Implementation of IClaimType

        public abstract bool Insert(ClaimTypeInfo obj);
        public abstract bool Update(ClaimTypeInfo obj);
        public abstract bool Delete(string id);
        public abstract ClaimTypeInfo GetById(string id);
        public abstract List<ClaimTypeInfo> GetAll();

        #endregion
    }
}
