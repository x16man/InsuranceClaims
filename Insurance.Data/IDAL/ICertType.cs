using System.Collections.Generic;
using Insurance.Data.Model;

namespace Insurance.Data.IDAL
{
    interface ICertType
    {
        bool Insert(CertTypeInfo obj);

        bool Update(CertTypeInfo obj);

        bool Delete(string id);

        CertTypeInfo GetById(string id);

        List<CertTypeInfo> GetAll();
    }
}
