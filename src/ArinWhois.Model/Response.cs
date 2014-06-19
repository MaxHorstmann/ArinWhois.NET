using System;
using System.Runtime.Serialization;

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
        public Net Net { get; set; }

        //public Org org { get; set; }
        //public Poc poc { get; set; }
    }

    public class Net
    {
        [DataMember(Name = "@termsOfUse")]
        public string TermsOfUse { get; set; }

        //public DateTime registrationDate { get; set; }
    }

    public class Org
    {

    }

    public class Poc
    {

    }



}
