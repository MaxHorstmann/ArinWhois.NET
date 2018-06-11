using System;
using Newtonsoft.Json;

namespace ArinWhois.Model
{
    public class Network
    {
        [JsonProperty("@termsOfUse")]
        public string TermsOfUse { get; set; }

        [JsonProperty("registrationDate")]
        public ValueWrapper<DateTime> RegistrationDate { get; set; }

        [JsonProperty("ref")]
        public ValueWrapper<string> Ref { get; set; }

        [JsonProperty("handle")]
        public ValueWrapper<string> Handle { get; set; }

        [JsonProperty("name")]
        public ValueWrapper<string> Name { get; set; }

        [JsonProperty("startAddress")]
        public ValueWrapper<string> StartAddress { get; set; }

        [JsonProperty("endAddress")]
        public ValueWrapper<string> EndAddress { get; set; }

        [JsonProperty("updateDate")]
        public ValueWrapper<DateTime> UpdateDate { get; set; }

        [JsonProperty("version")]
        public ValueWrapper<string> Version { get; set; }

        [JsonProperty("netBlocks")]
        public NetBlocks NetBlocks { get; set; }

        [JsonProperty("orgRef")]
        public OrgRef OrgRef { get; set; }
    }

    public class OrgRef
    {
        [JsonProperty("@name")]
        public string Name { get; set; }

        [JsonProperty("@handle")]
        public string Handle { get; set; }
    }

    public class NetBlocks
    {
        [JsonProperty("netBlock")]
        public NetBlock NetBlock { get; set; } // damn it, API sometimes sends an array here
    }

    public class NetBlock
    {
        [JsonProperty("cidrLength")]
        public ValueWrapper<string> CidrLength { get; set; }

        [JsonProperty("type")]
        public ValueWrapper<string> Type { get; set; }

        [JsonProperty("description")]
        public ValueWrapper<string> Description { get; set; }

        [JsonProperty("startAddress")]
        public ValueWrapper<string> StartAddress { get; set; }

        [JsonProperty("endAddress")]
        public ValueWrapper<string> EndAddress { get; set; }

        [JsonIgnore]
        public string Cidr => $"{StartAddress}/{CidrLength}";
    }
}