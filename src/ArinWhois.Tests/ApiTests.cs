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

            Assert.AreEqual(response.net.termsOfUse, "https://www.arin.net/whois_tou.html");

        }
    }
}
