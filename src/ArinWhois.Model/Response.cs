using System;
using System.Runtime.Serialization;

namespace ArinWhois.Model
{
    public class Response
    {
        // enabling this throws - bug in Jil?
        [DataMember(Name = "ns4:pft")]
        public Pft ns4pft { get; set; }
    }

    public class Pft
    {
        public Net net { get; set; }
        public Org org { get; set; }
        public Poc poc { get; set; }
    }

    public class Net
    {
        //public string termsOfUse { get; set; }
        //public DateTime registrationDate { get; set; }
    }

    public class Org
    {

    }

    public class Poc
    {

    }



}
