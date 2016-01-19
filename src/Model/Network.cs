using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ArinWhois.Model
{
    /// <summary>
    /// The network content of a ARIN whois query.
    /// </summary>
    public class Network
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

        //[DataMember(Name = "netBlocks")]
        public List<NetBlock> NetBlocks = new List<NetBlock>();

        [DataMember(Name = "orgRef")]
        public OrgRef OrgRef { get; set; }

        [DataMember(Name = "customerRef")]
        public OrgRef CustomerRef { get; set; }

    }

    /// <summary>
    /// The organization reference of an ARIN Whois query.
    /// </summary>
    public class OrgRef
    {
        [DataMember(Name = "@name")]
        public string Name { get; set; }

        [DataMember(Name = "@handle")]
        public string Handle { get; set; }
    }

    /// <summary>
    /// The customer reference of an ARIN Whois query.
    /// </summary>
    public class CustomerRef
    {
        [DataMember(Name = "@name")]
        public string Name { get; set; }

        [DataMember(Name = "@handle")]
        public string Handle { get; set; }
    }

    /// <summary>
    /// The netblock content of an ARIN Whois query.
    /// </summary>
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

        [IgnoreDataMember]
        public string Cidr
        {
            get { return string.Format("{0}/{1}", StartAddress, CidrLength); }
        }
    }
    
}
