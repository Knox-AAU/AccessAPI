using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Access_API.DAL
{
    public class SearchDAL
    {
        public SearchResults searchDAL(string url)
        {
            HttpWebResponse response =  Drivers.HttpRequest.getRequest(url);
            string json = response.GetResponseStream().ToString();
            SearchResults results = JsonConvert.DeserializeObject<SearchResults>(json);
            return results;
        }
    }
}
