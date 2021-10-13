using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading.Tasks;

namespace Access_API.Drivers
{
    public static class HttpRequest
    {
        public static HttpWebResponse getRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return response;
        }
    }
}
