﻿using System;
using System.Runtime.Serialization;

namespace ArinWhois.Model
{
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

        [DataMember(Name = "netBlocks")]
        public NetBlocks NetBlocks { get; set; }

        [DataMember(Name = "orgRef")]
        public OrgRef OrgRef { get; set; }

    }

    public class OrgRef
    {
        [DataMember(Name = "@name")]
        public string Name { get; set; }

        [DataMember(Name = "@handle")]
        public string Handle { get; set; }
    }

    public class NetBlocks
    {
        [DataMember(Name = "netBlock")]
        public NetBlock NetBlock { get; set; }  // damn it, API sometimes sends an array here
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

        [IgnoreDataMember]
        public string Cidr
        {
            get { return string.Format("{0}/{1}", StartAddress, CidrLength); }
        }
    }
    
}
