using Newtonsoft.Json;

namespace ArinWhois.Model
{
    public class ValueWrapper<T>
    {
        [JsonProperty("$")]
        public T Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}