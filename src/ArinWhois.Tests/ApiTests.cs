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
            Assert.AreEqual("Facebook, Inc.", ipResponse.Network.OrgRef.Name);

            var organizationHandle = ipResponse.Network.OrgRef.Handle;
            var organizationResponse = arinClient.QueryResourceAsync(organizationHandle.ToString(), ArinClient.ResourceType.Organization).Result;

            Assert.IsNotNull(organizationResponse);
            Assert.AreEqual("UNITED STATES", organizationResponse.Organization.iso3166_1.Name.Value);
            Assert.AreEqual("Menlo Park", organizationResponse.Organization.City.Value);
            Assert.AreEqual("CA", organizationResponse.Organization.iso3166_2.Value);
            Assert.AreEqual("94025", organizationResponse.Organization.PostalCode.Value);
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
            Assert.AreEqual("Time Warner Cable Internet LLC", ipResponse.Network.OrgRef.Name);

            var organizationHandle = ipResponse.Network.OrgRef.Handle;
            var organizationResponse = arinClient.QueryResourceAsync(organizationHandle.ToString(), ArinClient.ResourceType.Organization).Result;

            Assert.IsNotNull(organizationResponse);
            Assert.AreEqual("UNITED STATES", organizationResponse.Organization.iso3166_1.Name.Value);
            Assert.AreEqual("Herndon", organizationResponse.Organization.City.Value);
            Assert.AreEqual("VA", organizationResponse.Organization.iso3166_2.Value);
            Assert.AreEqual("20171", organizationResponse.Organization.PostalCode.Value);
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

            Assert.IsNotNull(ipResponse.Network.CustomerRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef.Name);
            Assert.AreEqual("Videotron Ltee", ipResponse.Network.CustomerRef.Name);

            var customerHandle = ipResponse.Network.CustomerRef.Handle;
            var customerResponse = arinClient.QueryResourceAsync(customerHandle.ToString(), ArinClient.ResourceType.Customer).Result;

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual("CANADA", customerResponse.Customer.iso3166_1.Name.Value);
            Assert.AreEqual("Montreal", customerResponse.Customer.City.Value);
            Assert.AreEqual("QC", customerResponse.Customer.iso3166_2.Value);
            Assert.AreEqual("H2X 3W4", customerResponse.Customer.PostalCode.Value);
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

            Assert.IsNotNull(ipResponse.Network.CustomerRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef.Name);
            Assert.AreEqual("Cox Communications", ipResponse.Network.CustomerRef.Name);

            var customerHandle = ipResponse.Network.CustomerRef.Handle;
            var customerResponse = arinClient.QueryResourceAsync(customerHandle.ToString(), ArinClient.ResourceType.Customer).Result;

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual("UNITED STATES", customerResponse.Customer.iso3166_1.Name.Value);
            Assert.AreEqual("Atlanta", customerResponse.Customer.City.Value);
            Assert.AreEqual("GA", customerResponse.Customer.iso3166_2.Value);
            Assert.AreEqual("30319", customerResponse.Customer.PostalCode.Value);
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
            Assert.AreEqual("AT&T Internet Services", ipResponse.Network.OrgRef.Name);

            var organizationHandle = ipResponse.Network.OrgRef.Handle;
            var organizationResponse = arinClient.QueryResourceAsync(organizationHandle.ToString(), ArinClient.ResourceType.Organization).Result;

            Assert.IsNotNull(organizationResponse);
            Assert.AreEqual("UNITED STATES", organizationResponse.Organization.iso3166_1.Name.Value);
            Assert.AreEqual("Richardson", organizationResponse.Organization.City.Value);
            Assert.AreEqual("TX", organizationResponse.Organization.iso3166_2.Value);
            Assert.AreEqual("75082", organizationResponse.Organization.PostalCode.Value);
        }

        [TestMethod]
        public void TestIp6Found()
        {
            var arinClient = new ArinClient();
            var ipResponse = arinClient.QueryIpAsync(IPAddress.Parse("174.65.101.118")).Result;

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNull(ipResponse.Network.OrgRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef);

            Assert.IsNotNull(ipResponse.Network.CustomerRef.Name);
            Assert.AreEqual("Cox Communications", ipResponse.Network.CustomerRef.Name);

            var customerHandle = ipResponse.Network.CustomerRef.Handle;
            var customerResponse = arinClient.QueryResourceAsync(customerHandle.ToString(), ArinClient.ResourceType.Customer).Result;

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual("UNITED STATES", customerResponse.Customer.iso3166_1.Name.Value);
            Assert.AreEqual("Atlanta", customerResponse.Customer.City.Value);
            Assert.AreEqual("GA", customerResponse.Customer.iso3166_2.Value);
            Assert.AreEqual("30319", customerResponse.Customer.PostalCode.Value);
        }

        [TestMethod]
        public void TestIp7Found()
        {
            var arinClient = new ArinClient();
            var ipResponse = arinClient.QueryIpAsync(IPAddress.Parse("174.34.144.69")).Result;

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0]);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks[0].Description);

            Assert.IsNotNull(ipResponse.Network.OrgRef);

            Assert.IsNotNull(ipResponse.Network.OrgRef.Name);
            Assert.AreEqual("Ubiquity Server Solutions Seattle", ipResponse.Network.OrgRef.Name);

            var organizationHandle = ipResponse.Network.OrgRef.Handle;
            var organizationResponse = arinClient.QueryResourceAsync(organizationHandle.ToString(), ArinClient.ResourceType.Organization).Result;

            Assert.IsNotNull(organizationResponse);
            Assert.AreEqual("12101 Tukwila International Blvd", organizationResponse.Organization.StreetAddress.Line[0].Value.Trim());
            Assert.AreEqual("Suite 100", organizationResponse.Organization.StreetAddress.Line[1].Value.Trim());
            Assert.AreEqual("UNITED STATES", organizationResponse.Organization.iso3166_1.Name.Value);
            Assert.AreEqual("Tukwila", organizationResponse.Organization.City.Value);
            Assert.AreEqual("WA", organizationResponse.Organization.iso3166_2.Value);
            Assert.AreEqual("98168", organizationResponse.Organization.PostalCode.Value);
        }
    }
}
