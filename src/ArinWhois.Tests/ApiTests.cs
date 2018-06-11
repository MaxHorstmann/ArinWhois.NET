using System.Net;
using System.Threading.Tasks;
using ArinWhois.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArinWhois.Tests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async Task TestIpFound()
        {
            var arinClient = new ArinClient();
            var ipResponse = arinClient.QueryIpAsync(IPAddress.Parse("69.63.176.0")).Result;

            Assert.IsNotNull(ipResponse);
            Assert.IsNotNull(ipResponse.Network);

            Assert.IsTrue(ipResponse.Network.TermsOfUse.StartsWith("http"));
            Assert.IsNotNull(ipResponse.Network.RegistrationDate.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks.NetBlock);
            Assert.IsNotNull(ipResponse.Network.NetBlocks.NetBlock.CidrLength.Value);
            Assert.IsNotNull(ipResponse.Network.NetBlocks.NetBlock.Description);

            Assert.IsNotNull(ipResponse.Network.OrgRef.Name);
            Assert.AreEqual(ipResponse.Network.OrgRef.Name, "Facebook, Inc.");

            var organizationHandle = ipResponse.Network.OrgRef.Handle;
            var organizationResponse =
                await arinClient.QueryResourceAsync(organizationHandle, ArinClient.ResourceType.Organization);

            Assert.IsNotNull(organizationResponse);
            Assert.AreEqual(organizationResponse.Organization.City.Value, "Menlo Park");
        }

        [TestMethod]
        public async Task TestIpNotFound()
        {
            var arinClient = new ArinClient();
            var response = await arinClient.QueryIpAsync(IPAddress.Parse("108.33.73.20"));
            Assert.IsNull(response);
        }
    }
}