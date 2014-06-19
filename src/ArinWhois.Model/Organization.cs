using System;
using System.Runtime.Serialization;

namespace ArinWhois.ArinWhois.Model
{
    public class Organization
    {
        [DataMember(Name = "@termsOfUse")]
        public string TermsOfUse { get; set; }

        [DataMember(Name = "registrationDate")]
        public ValueWrapper<DateTime> RegistrationDate { get; set; }
    }
}
