using System.Collections.Generic;
using Insurance.Data.Model;

namespace Insurance.Data.IDAL
{
    interface IStaff
    {
        long Insert(StaffInfo obj);

        bool Update(StaffInfo obj);

        bool Delete(long id);

        StaffInfo GetById(long id);

        StaffInfo GetByCCC(long customerId, string certId, string certTypeId);

        List<StaffInfo> GetByCustomerId(long customerId);


    }
}
