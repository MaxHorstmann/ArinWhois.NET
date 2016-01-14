using System;
using System.Net;
using ArinWhois.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArinWhois.Tests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void TestIpFound()
        {
            var arinClient = new ArinClient();
            var ipResponse = arinClient.QueryIpAsync(IPAddress.Parse("69.63.176.0")).Result;

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNotNull(ipResponse.Network.OrgRef.Name);
            Assert.AreEqual(ipResponse.Network.OrgRef.Name, "Facebook, Inc.");

            var organizationHandle = ipResponse.Network.OrgRef.Handle;
            var organizationResponse = arinClient.QueryResourceAsync(organizationHandle.ToString(), ArinClient.ResourceType.Organization).Result;

            Assert.IsNotNull(organizationResponse);
            Assert.AreEqual(organizationResponse.Organization.iso3166_1.Name.Value, "UNITED STATES");
            Assert.AreEqual(organizationResponse.Organization.City.Value, "Menlo Park");
            Assert.AreEqual(organizationResponse.Organization.iso3166_2.Value, "CA");
            Assert.AreEqual(organizationResponse.Organization.PostalCode.Value, "94025");
        }

        [TestMethod]
        public void TestIp2Found()
        {
            var arinClient = new ArinClient();
            var ipResponse = arinClient.QueryIpAsync(IPAddress.Parse("98.155.64.40")).Result;

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNotNull(ipResponse.Network.OrgRef.Name);
            Assert.AreEqual(ipResponse.Network.OrgRef.Name, "Time Warner Cable Internet LLC");

            var organizationHandle = ipResponse.Network.OrgRef.Handle;
            var organizationResponse = arinClient.QueryResourceAsync(organizationHandle.ToString(), ArinClient.ResourceType.Organization).Result;

            Assert.IsNotNull(organizationResponse);
            Assert.AreEqual(organizationResponse.Organization.iso3166_1.Name.Value, "UNITED STATES");
            Assert.AreEqual(organizationResponse.Organization.City.Value, "Herndon");
            Assert.AreEqual(organizationResponse.Organization.iso3166_2.Value, "VA");
            Assert.AreEqual(organizationResponse.Organization.PostalCode.Value, "20171");
        }

        [TestMethod]
        public void TestIp3Found()
        {
            var arinClient = new ArinClient();
            var ipResponse = arinClient.QueryIpAsync(IPAddress.Parse("96.21.63.199")).Result;

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNull(ipResponse.Network.OrgRef);
        }

        [TestMethod]
        public void TestIp4Found()
        {
            var arinClient = new ArinClient();
            var ipResponse = arinClient.QueryIpAsync(IPAddress.Parse("98.176.133.1")).Result;

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNull(ipResponse.Network.OrgRef);
        }

        [TestMethod]
        public void TestIp5Found()
        {
            var arinClient = new ArinClient();
            var ipResponse = arinClient.QueryIpAsync(IPAddress.Parse("108.234.177.20")).Result;

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNotNull(ipResponse.Network.OrgRef);

            Assert.IsNotNull(ipResponse.Network.OrgRef.Name);
            Assert.AreEqual(ipResponse.Network.OrgRef.Name, "AT&T Internet Services");

            var organizationHandle = ipResponse.Network.OrgRef.Handle;
            var organizationResponse = arinClient.QueryResourceAsync(organizationHandle.ToString(), ArinClient.ResourceType.Organization).Result;

            Assert.IsNotNull(organizationResponse);
            Assert.AreEqual(organizationResponse.Organization.iso3166_1.Name.Value, "UNITED STATES");
            Assert.AreEqual(organizationResponse.Organization.City.Value, "Richardson");
            Assert.AreEqual(organizationResponse.Organization.iso3166_2.Value, "TX");
            Assert.AreEqual(organizationResponse.Organization.PostalCode.Value, "75082");

        }


        // 
        // This is not needed because ARIN will always return something
        //
        //[TestMethod]
        //public void TestIpNotFound()
        //{
        //    var arinClient = new ArinClient();
        //    var response = arinClient.QueryIpAsync(IPAddress.Parse("108.33.73.20")).Result;
        //    Assert.IsNull(response);
        //}
    }
}
