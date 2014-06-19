using System.Runtime.Serialization;
using ArinWhois.ArinWhois.Model;

namespace ArinWhois.Model
{
    internal class ResponseOuter
    {
        [DataMember(Name = "ns4:pft")]
        public Response ResponseInner { get; set; }
    }

    public class Response
    {
        [DataMember(Name = "net")]
        public Network Network { get; set; }

        [DataMember(Name = "org")]
        public Organization Organization { get; set; }

        //public Poc poc { get; set; }
    }

}
