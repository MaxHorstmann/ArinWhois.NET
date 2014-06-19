using System;
using System.Runtime.Serialization;

namespace ArinWhois.Model
{
    public class Organization
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
    }
}
