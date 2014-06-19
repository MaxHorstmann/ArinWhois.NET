using System;
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

            // http://whois.arin.net/rest/net/NET-69-63-176-0-1/pft.json
            // sync over async, ok for test. http://blogs.msdn.com/b/pfxteam/archive/2012/04/13/10293638.aspx
            var response = arinClient.QueryNetworkAsync("69.63.176.0").Result;

            Assert.IsTrue(response.Net.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(response.Net.RegistrationDate.Value);
            Assert.IsNotNull(response.Net.NetBlocks.NetBlock);
            Assert.IsNotNull(response.Net.NetBlocks.NetBlock.CidrLength.Value);
            Assert.IsNotNull(response.Net.NetBlocks.NetBlock.Description);


        }
    }
}
