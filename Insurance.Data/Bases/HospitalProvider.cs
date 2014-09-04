using System.Collections.Generic;
using System.Data;
using Insurance.Data.Model;

namespace Insurance.Data.Bases
{
    public abstract class HospitalProvider:IDAL.IHospital
    {
        #region protected method
        protected HospitalInfo ConvertToObject(IDataRecord dr)
        {
            var obj = new HospitalInfo();
            obj.Id = dr["Id"].ToString();
            obj.OldId = obj.Id;
            obj.Name = dr["Name"].ToString();

            return obj;
        }
        #endregion

        #region Implementation of IHospital

        public abstract bool Insert(HospitalInfo obj);
        public abstract bool Update(HospitalInfo obj);
        public abstract bool Delete(string id);
        public abstract HospitalInfo GetById(string id);
        public abstract List<HospitalInfo> GetAll();

        #endregion
    }
}
