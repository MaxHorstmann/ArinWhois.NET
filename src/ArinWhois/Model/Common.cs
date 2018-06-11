using System.Runtime.Serialization;

namespace ArinWhois.Model
{
    public class ValueWrapper<T>
    {
        [DataMember(Name = "$")]
        public T Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
