using System.Collections.Generic;
using Insurance.Data.Model;

namespace Insurance.Data.IDAL
{
    interface IClaimType
    {
        bool Insert(ClaimTypeInfo obj);

        bool Update(ClaimTypeInfo obj);

        bool Delete(string id);

        ClaimTypeInfo GetById(string id);

        List<ClaimTypeInfo> GetAll();
    }
}
