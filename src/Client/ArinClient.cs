namespace ArinWhois.Client
{
    public class ArinClient
    {
        private const string BaseUrl = "http://whois.arin.net/rest";

        private static string GetRequestUrl(string query)
        {
            return string.Format("{0}/{1}.json", BaseUrl, query);
        }
        


    }

}
