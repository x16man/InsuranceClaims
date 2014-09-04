using System;

namespace Insurance.Data.Model
{
    [Serializable]
    public class StaffInfo
    {
        #region Property
        public long Id { get; set; }
        public string CertTypeId { get; set; }
        public string CertId { get; set; }
        public long CustomerId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Company { get; set;}
        public string Department { get; set; }
        public string Bank { get; set; }
        public string Account { get; set; }
        

        #endregion
    }
}
