using System;
using Newtonsoft.Json;

namespace ArinWhois.Model
{
    public class PointOfContact
    {
        [JsonProperty("@termsOfUse")]
        public string TermsOfUse { get; set; }

        [JsonProperty("registrationDate")]
        public ValueWrapper<DateTime> RegistrationDate { get; set; }

        [JsonProperty("ref")]
        public ValueWrapper<string> Ref { get; set; }
    }
}