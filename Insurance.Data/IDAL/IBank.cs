using System.Collections.Generic;
using Insurance.Data.Model;

namespace Insurance.Data.IDAL
{
    interface IBank
    {
        bool Insert(BankInfo obj);

        bool Update(BankInfo obj);

        bool Delete(string id);

        BankInfo GetById(string id);

        List<BankInfo> GetAll();
    }
}
