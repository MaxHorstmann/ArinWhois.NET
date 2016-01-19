using System;
using System.Net;
using System.Threading.Tasks;
using ArinWhois.Model;
using Jil;
using System.Collections.Generic;


namespace ArinWhois.Client
{
    public class ArinClient
    {
        /// <summary>
        /// The base URL for ARIN whois.
        /// </summary>
        private const string BaseUrl = "http://whois.arin.net/rest";

        /// <summary>
        /// Options for the JSON deserialization process.
        /// </summary>
        private static readonly Options DeserializationOptions = Options.ISO8601ExcludeNulls;

        /// <summary>
        /// The types of resources that can be queried through ARIN.
        /// </summary>
        public enum ResourceType
        {
            Unknown = 0,
            Network = 1,
            Organization = 2,
            PointOfContact = 3,
            Customer = 4
        }

        /// <summary>
        /// Query an IP address, async
        /// </summary>
        /// <param name="ip">The IP address to query.</param>
        /// <returns>Returns an async task with the response.</returns>
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
                    var deserdyn = JSON.DeserializeDynamic(jsonString, DeserializationOptions);
                    var netblock_ser = deserdyn["net"]["netBlocks"]["netBlock"];

                    try
                    {
                        // Take care of non-array
                        NetBlock netblock = JSON.Deserialize<NetBlock>(JSON.SerializeDynamic(netblock_ser), DeserializationOptions);
                        deser.Network.NetBlocks.Add(netblock);
                        return deser;
                    }
                    catch
                    {
                    }

                    // Take care of array
                    List<NetBlock> netblocks = JSON.Deserialize<List<NetBlock>>(JSON.SerializeDynamic(netblock_ser), DeserializationOptions);
                    deser.Network.NetBlocks = netblocks;

                    return deser;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Queries a resource record on a handle.
        /// </summary>
        /// <param name="handle">The handle to query.</param>
        /// <param name="resourceType">The type of resource record to query.</param>
        /// <returns>Returns an async task of the response.</returns>
        public async Task<Response> QueryResourceAsync(string handle, ResourceType resourceType)
        {
            if (resourceType != ResourceType.Organization && resourceType != ResourceType.Customer) throw new NotImplementedException(); // coming soon

            using (var wc = new WebClient())
            {
                switch (resourceType)
                {
                    case ResourceType.Organization:
                        try
                        {
                            var query = string.Format("org/{0}", handle);
                            var jsonString = await wc.DownloadStringTaskAsync(GetRequestUrl(query));
                            var deser = JSON.Deserialize<Response>(jsonString, DeserializationOptions);

                            var deserdyn = JSON.DeserializeDynamic(jsonString, DeserializationOptions);
                            var streetaddress_ser = deserdyn["org"]["streetAddress"]["line"];

                            try
                            {
                                ValueWrapper<string> streetaddress = JSON.Deserialize<ValueWrapper<string>>(JSON.SerializeDynamic(streetaddress_ser), DeserializationOptions);
                                deser.Organization.StreetAddress.Line.Add(streetaddress);
                                return deser;
                            }
                            catch
                            {

                            }

                            List<ValueWrapper<string>> streetaddresses = JSON.Deserialize<List<ValueWrapper<string>>>(JSON.SerializeDynamic(streetaddress_ser), DeserializationOptions);
                            deser.Organization.StreetAddress.Line = streetaddresses;

                            return deser;
                        }
                        catch
                        {
                            return null;
                        }

                    case ResourceType.Customer:
                        try
                        {
                            var query = string.Format("customer/{0}", handle);
                            var jsonString = await wc.DownloadStringTaskAsync(GetRequestUrl(query));
                            var deser = JSON.Deserialize<Response>(jsonString, DeserializationOptions);

                            var deserdyn = JSON.DeserializeDynamic(jsonString, DeserializationOptions);
                            var streetaddress_ser = deserdyn["customer"]["streetAddress"]["line"];

                            try
                            {
                                ValueWrapper<string> streetaddress = JSON.Deserialize<ValueWrapper<string>>(JSON.SerializeDynamic(streetaddress_ser), DeserializationOptions);
                                deser.Customer.StreetAddress.Line.Add(streetaddress);
                                return deser;
                            }
                            catch
                            {

                            }

                            List<ValueWrapper<string>> streetaddresses = JSON.Deserialize<List<ValueWrapper<string>>>(JSON.SerializeDynamic(streetaddress_ser), DeserializationOptions);
                            deser.Customer.StreetAddress.Line = streetaddresses;

                            return deser;
                        }
                        catch
                        {
                            return null;
                        }
                }
            }
            return null;
        }

        /// <summary>
        /// Builds the string for the ARIN request.
        /// </summary>
        /// <param name="query">The query to perform.</param>
        /// <returns>The formatted URL.</returns>
        private static Uri GetRequestUrl(string query)
        {
            return new Uri(string.Format("{0}/{1}.json", BaseUrl, query));
        }

    }

}
