using System;
using System.Collections.Generic;
using System.Text;
using Insurance.Data.Model;

namespace Insurance.Data.IDAL
{
    interface IHospital
    {
        bool Insert(HospitalInfo obj);

        bool Update(HospitalInfo obj);

        bool Delete(string id);

        HospitalInfo GetById(string id);

        List<HospitalInfo> GetAll();
    }
}
