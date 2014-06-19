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

        [DataMember(Name = "registrationDate")]
        public ValueWrapper<DateTime> RegistrationDate { get; set; }
    }

    public class Org
    {

    }

    public class Poc
    {

    }

    public class ValueWrapper<T>
    {
        [DataMember(Name = "$")]
        public T Value { get; set; }
    }

}
