using System;
using System.Net;
using System.Threading.Tasks;
using ArinWhois.Model;

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
                return null; // TODO toJSON
            }
        }


        private static Uri GetRequestUrl(string query)
        {
            return new Uri(string.Format("{0}/{1}.json", BaseUrl, query)));
        }
        


    }

}
