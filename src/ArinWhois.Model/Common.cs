using System.Runtime.Serialization;

namespace ArinWhois.ArinWhois.Model
{
    public class ValueWrapper<T>
    {
        [DataMember(Name = "$")]
        public T Value { get; set; }
    }
}
