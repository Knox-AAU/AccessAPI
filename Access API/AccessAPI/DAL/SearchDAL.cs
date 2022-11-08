using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace Access_API.DAL
{
    public class SearchDAL
    {
        public SearchResultsDTO GetSearchResults(string url)
        {
            string json = null;
            HttpWebResponse response = Drivers.HttpRequest.GetRequest(url);
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                json = sr.ReadToEnd();
            }
            SearchResultsDTO results = JsonConvert.DeserializeObject<SearchResultsDTO>(json.ToString());
            return results;
        }
    }
}
