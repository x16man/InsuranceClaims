namespace InsuranceClaims.AppCode
{
    public class KeyValuePair
    {
        public object Key;
        public string Value;
     
        public KeyValuePair(object newKey,string newValue)
        {
            Key = newKey;
            Value = newValue;
        }
     
        public override string ToString()
        {
            return Value;
        }
    }
}
