using System.Runtime.Serialization;

namespace ArinWhois.Model
{
    /// <summary>
    /// Wraps a value of a response from the ARIN Whois server.  The server uses a "$" value for most values.
    /// </summary>
    /// <typeparam name="T">The type of value to be wrapped.</typeparam>
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
