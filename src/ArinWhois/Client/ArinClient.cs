using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ArinWhois.Model;
using Newtonsoft.Json;

namespace ArinWhois.Client
{
    public class ArinClient
    {
        public enum ResourceType
        {
            Unknown = 0,
            Network = 1,
            Organization = 2,
            PointOfContact = 3
        }

        private const string BaseUrl = "http://whois.arin.net/rest";

        private readonly HttpClient _httpClient = new HttpClient();

        private readonly JsonSerializerSettings _serializerSettings =
            new JsonSerializerSettings {DateFormatHandling = DateFormatHandling.IsoDateFormat};

        public async Task<Response> QueryIpAsync(IPAddress ip)
        {
            try
            {
                var query = $"ip/{ip}";
                var url = GetRequestUrl(query);
                var jsonString = await _httpClient.GetStringAsync(url);
                var deser = JsonConvert.DeserializeObject<Response>(jsonString, _serializerSettings);
                return deser;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Response> QueryResourceAsync(string handle, ResourceType resourceType)
        {
            if (resourceType != ResourceType.Organization) throw new NotImplementedException(); // coming soon

            try
            {
                var query = $"org/{handle}/pft";
                var jsonString = await _httpClient.GetStringAsync(GetRequestUrl(query));
                var deser = JsonConvert.DeserializeObject<ResponseOuter>(jsonString, _serializerSettings);
                return deser.ResponseInner;
            }
            catch
            {
                return null;
            }
        }

        private static Uri GetRequestUrl(string query)
        {
            return new Uri($"{BaseUrl}/{query}.json");
        }
    }
}