using System.Net;

namespace Access_API.DAL
{
    public class PingDal
    {
        public HttpWebResponse PingDb(string query)
        {
            HttpWebResponse response = Drivers.HttpRequest.GetRequest($"{Urls.RdfUrl}/{query}");
            return response;
        }
    }
}