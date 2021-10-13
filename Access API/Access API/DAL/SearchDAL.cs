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
            //HttpWebResponse response =  Drivers.HttpRequest.getRequest(url);
            //string json = response.GetResponseStream().ToString();
            string json = "{" +
   "\"result\":[" +
      "{" +
                "\"title\":\"Sine blev sendt i kræftbehandling på Rigshospitalet. Hun kom aldrig hjem igen\"," +
         "\"filepath\":\"/mnt/data/srv/data/newsarchive/2020-12-04/TabletXML/00_12_2-_sektion_fre_s012_02_nordjyll_0412_202012040000_1014942548.xml\"," +
        "\"score\":0.579903985789051" +
      "}" +
   "]" +
"}"; 
            SearchResults results = JsonConvert.DeserializeObject<SearchResults>(json);
            return results;
        }
    }
}
