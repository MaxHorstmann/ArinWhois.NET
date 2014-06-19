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

        [DataMember(Name = "ref")]
        public ValueWrapper<string> Ref { get; set; }

        [DataMember(Name = "handle")]
        public ValueWrapper<string> Handle { get; set; }

        [DataMember(Name = "name")]
        public ValueWrapper<string> Name { get; set; }

        [DataMember(Name = "startAddress")]
        public ValueWrapper<string> StartAddress { get; set; }

        [DataMember(Name = "endAddress")]
        public ValueWrapper<string> EndAddress { get; set; }

        [DataMember(Name = "updateDate")]
        public ValueWrapper<DateTime> UpdateDate { get; set; }

        [DataMember(Name = "version")]
        public ValueWrapper<string> Version { get; set; }

        [DataMember(Name = "netBlocks")]
        public NetBlocks NetBlocks { get; set; }

    }

    public class NetBlocks
    {
        [DataMember(Name = "netBlock")]
        public NetBlock NetBlock { get; set; }
    }

    public class NetBlock
    {
        [DataMember(Name = "cidrLength")]
        public ValueWrapper<string> CidrLength { get; set; }

        [DataMember(Name = "type")]
        public ValueWrapper<string> Type { get; set; }

        [DataMember(Name = "description")]
        public ValueWrapper<string> Description { get; set; }

        [DataMember(Name = "startAddress")]
        public ValueWrapper<string> StartAddress { get; set; }

        [DataMember(Name = "endAddress")]
        public ValueWrapper<string> EndAddress { get; set; } 
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
