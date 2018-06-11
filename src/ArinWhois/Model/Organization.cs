using System;
using Newtonsoft.Json;

namespace ArinWhois.Model
{
    public class Organization
    {
        [JsonProperty("@termsOfUse")]
        public string TermsOfUse { get; set; }

        [JsonProperty("registrationDate")]
        public ValueWrapper<DateTime> RegistrationDate { get; set; }

        [JsonProperty("name")]
        public ValueWrapper<string> Name { get; set; }

        [JsonProperty("postalCode")]
        public ValueWrapper<string> PostalCode { get; set; }

        [JsonProperty("city")]
        public ValueWrapper<string> City { get; set; }

        [JsonProperty("updateDate")]
        public ValueWrapper<DateTime> UpdateDate { get; set; }
    }
}