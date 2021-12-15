using System.Net;

namespace Access_API.Drivers
{
    public static class HttpRequest
    {
        public static HttpWebResponse GetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return response;
        }
    }
}
