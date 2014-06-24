using System;
using System.Net;
using System.Threading.Tasks;
using ArinWhois.Model;
using Jil;

namespace ArinWhois.Client
{
    public class ArinClient
    {
        private const string BaseUrl = "http://whois.arin.net/rest";

        private static readonly Options DeserializationOptions = Options.ISO8601;

        public enum ResourceType
        {
            Unknown = 0,
            Network = 1,
            Organization = 2,
            PointOfContact = 3
        }

        public async Task<Response> QueryIpAsync(IPAddress ip)
        {
            using (var wc = new WebClient())
            {
                try
                {
                    var query = string.Format("ip/{0}", ip);
                    var url = GetRequestUrl(query);
                    var jsonString = await wc.DownloadStringTaskAsync(url);
                    var deser = JSON.Deserialize<Response>(jsonString, DeserializationOptions);
                    return deser;
                }
                catch
                {
                    return null;
                }
            }
        }

        public async Task<Response> QueryResourceAsync(string handle, ResourceType resourceType)
        {
            if (resourceType != ResourceType.Organization) throw new NotImplementedException(); // coming soon

            using (var wc = new WebClient())
            {
                try
                {
                    var query = string.Format("org/{0}/pft", handle);
                    var jsonString = await wc.DownloadStringTaskAsync(GetRequestUrl(query));
                    var deser = JSON.Deserialize<ResponseOuter>(jsonString, DeserializationOptions);
                    return deser.ResponseInner;
                }
                catch
                {
                    return null;
                }
            }
        }


        private static Uri GetRequestUrl(string query)
        {
            return new Uri(string.Format("{0}/{1}.json", BaseUrl, query));
        }
        


    }

}
