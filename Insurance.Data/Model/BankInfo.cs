using System;

namespace Insurance.Data.Model
{
    [Serializable]
    public class BankInfo
    {
        #region Property
        public string OldId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        #endregion
    }
}
