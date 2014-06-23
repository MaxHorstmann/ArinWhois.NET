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
        public void TestNetwork()
        {
            var arinClient = new ArinClient();
            var response = arinClient.QueryAsync(IPAddress.Parse("69.63.176.0")).Result;

            Assert.IsNotNull(response.Network);
            Assert.IsNotNull(response.Organization);
            Assert.IsNotNull(response.PointOfContact);

            Assert.IsTrue(response.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(response.Network.RegistrationDate.Value);
            Assert.IsNotNull(response.Network.NetBlocks.NetBlock);
            Assert.IsNotNull(response.Network.NetBlocks.NetBlock.CidrLength.Value);
            Assert.IsNotNull(response.Network.NetBlocks.NetBlock.Description);
        }

        [TestMethod]
        public void TestNotFound()
        {
            var arinClient = new ArinClient();
            var response = arinClient.QueryAsync(IPAddress.Parse("189.167.158.151")).Result;
            Assert.IsNull(response);
        }

    }
}
