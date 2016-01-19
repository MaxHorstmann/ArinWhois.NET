using System;
using System.Runtime.Serialization;

namespace ArinWhois.Model
{
    /// <summary>
    /// A point of contact content of an ARIN Whois query.  Currently not used.
    /// </summary>
    public class PointOfContact
    {
        [DataMember(Name = "@termsOfUse")]
        public string TermsOfUse { get; set; }

        [DataMember(Name = "registrationDate")]
        public ValueWrapper<DateTime> RegistrationDate { get; set; }

        [DataMember(Name = "ref")]
        public ValueWrapper<string> Ref { get; set; }
    }
}
