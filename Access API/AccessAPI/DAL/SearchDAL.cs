using System;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace Access_API.DAL
{
    public class SearchDAL
    {
        public string GetSearchResults(string url)
        {
            HttpWebResponse response = Drivers.HttpRequest.GetRequest(url);
            using System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = sr.ReadToEnd();

            // SearchResultsDTO results = JsonConvert.DeserializeObject<SearchResultsDTO>(json)!;
            return json;
        }
    }
}
