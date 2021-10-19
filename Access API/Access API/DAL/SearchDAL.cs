using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Access_API.DAL
{
    public class SearchDAL
    {
        public SearchResults searchDAL(string url)
        {
            string json = null;
            HttpWebResponse response = Drivers.HttpRequest.getRequest("https://localhost:44347/api/test");
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), Encoding.ASCII))
            {
                json = sr.ReadToEnd();
            }
                
         /*   string json = "{" +
   "\"result\":[" +
      "{" +
                "\"title\":\"Sine blev sendt i kræftbehandling på Rigshospitalet. Hun kom glad hjem igen\"," +
         "\"filepath\":\"/mnt/data/srv/data/newsarchive/2020-12-04/TabletXML/00_12_2-_sektion_fre_s012_02_nordjyll_0412_202012040000_1014942548.xml\"," +
        "\"score\":0.579903985789051" +
      "}" +
   "]" +
"}"; */
            SearchResults results = JsonConvert.DeserializeObject<SearchResults>(json.ToString());
            return results;
        }
    }
}
