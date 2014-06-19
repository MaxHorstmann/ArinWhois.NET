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

        public async Task<Response> QueryNetworkAsync(string ip)
        {
            using (var wc = new WebClient())
            {
                var query = string.Format("net/NET-{0}-1/pft", ip.Replace(".", "-"));
                var response = await wc.DownloadStringTaskAsync(GetRequestUrl(query));
                //var result = JSON.DeserializeDynamic(response);
                return  JSON.Deserialize<Response>(response);
            }
        }

        private static Uri GetRequestUrl(string query)
        {
            var uri = string.Format("{0}/{1}.json", BaseUrl, query);
            return new Uri(uri);
        }
        


    }

}
