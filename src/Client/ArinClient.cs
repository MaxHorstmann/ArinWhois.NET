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

        public async Task<Response> QueryIpAsync(IPAddress ip)
        {
            using (var wc = new WebClient())
            {
                var query = string.Format("ip/{0}", ip);
                var jsonString = await wc.DownloadStringTaskAsync(GetRequestUrl(query));
                var deser = JSON.Deserialize<Response>(jsonString, DeserializationOptions);
                return deser;
            }
        }

        public async Task<Response> QueryNetworkAsync(string handle)
        {
            using (var wc = new WebClient())
            {
                var query = string.Format("net/{0}/pft", handle);
                var jsonString = await wc.DownloadStringTaskAsync(GetRequestUrl(query));
                var deser = JSON.Deserialize<ResponseOuter>(jsonString, DeserializationOptions);
                return deser.ResponseInner;
            }
        }


        private static Uri GetRequestUrl(string query)
        {
            return new Uri(string.Format("{0}/{1}.json", BaseUrl, query));
        }
        


    }

}
