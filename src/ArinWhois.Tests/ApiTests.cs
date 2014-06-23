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
            var response = arinClient.QueryIpAsync(IPAddress.Parse("69.63.176.0")).Result;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Network);

            Assert.IsTrue(response.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(response.Network.RegistrationDate.Value);
            Assert.IsNotNull(response.Network.NetBlocks.NetBlock);
            Assert.IsNotNull(response.Network.NetBlocks.NetBlock.CidrLength.Value);
            Assert.IsNotNull(response.Network.NetBlocks.NetBlock.Description);
        }

        [TestMethod]
        public void TestIpNotFound()
        {
            var arinClient = new ArinClient();
            var response = arinClient.QueryIpAsync(IPAddress.Parse("108.33.73.20")).Result;
            Assert.IsNull(response);
        }


        [TestMethod]
        public void TestNetwork()
        {
            var arinClient = new ArinClient();
            var response = arinClient.QueryNetworkAsync("NET-69-63-176-0-1").Result;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Network);
            Assert.IsNotNull(response.Organization);
            Assert.IsNotNull(response.PointOfContact);

            Assert.AreEqual(response.Organization.Name.Value, "Facebook, Inc.");
        }




    }
}
