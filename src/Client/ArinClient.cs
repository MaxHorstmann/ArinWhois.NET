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

        public async Task<Response> QueryAsync(IPAddress ip)
        {
            using (var wc = new WebClient())
            {
                var query = string.Format("net/NET-{0}-1/pft", ip.ToString().Replace(".", "-"));
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
