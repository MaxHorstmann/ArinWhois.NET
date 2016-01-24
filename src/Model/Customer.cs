using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ArinWhois.Model
{
    /// <summary>
    /// The customer content of an ARIN Whois response.
    /// </summary>
    public class Customer
    {
        [DataMember(Name = "@termsOfUse")]
        public string TermsOfUse { get; set; }

        [DataMember(Name = "registrationDate")]
        public ValueWrapper<DateTime> RegistrationDate { get; set; }

        [DataMember(Name = "name")]
        public ValueWrapper<string> Name { get; set; }

        [DataMember(Name = "postalCode")]
        public ValueWrapper<string> PostalCode { get; set; }

        [DataMember(Name = "city")]
        public ValueWrapper<string> City { get; set; }

        [DataMember(Name = "updateDate")]
        public ValueWrapper<DateTime> UpdateDate { get; set; }

        [DataMember(Name = "ref")]
        public ValueWrapper<string> Ref { get; set; }

        [DataMember(Name = "iso3166-1")]
        public iso3166_1 iso3166_1 { get; set; }

        [DataMember(Name = "iso3166-2")]
        public ValueWrapper<string> iso3166_2 { get; set; }

        [DataMember(Name = "streetAddress")]
        public StreetAddress StreetAddress { get; set; }
    }
}
