using System.Runtime.Serialization;

namespace ArinWhois.Model
{
    /// <summary>
    /// A response from the ARIN Whois server.
    /// </summary>
    public class Response
    {
        [DataMember(Name = "net")]
        public Network Network { get; set; }

        [DataMember(Name = "org")]
        public Organization Organization { get; set; }

        [DataMember(Name = "poc")]
        public PointOfContact PointOfContact { get; set; }

        [DataMember(Name = "customer")]
        public Customer Customer { get; set; }
    }
}
