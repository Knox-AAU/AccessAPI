using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Text;


namespace Access_API.DAL
{
    public class VADAL
    {
        public VAResultsDTO GetVAResults(string url)
        {
            string json = null;
            HttpWebResponse response = Drivers.HttpRequest.getRequest(url);
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), Encoding.ASCII))
            {
                json = sr.ReadToEnd();
            }
            VAResultsDTO results = JsonConvert.DeserializeObject<VAResultsDTO>(json.ToString());
            return results;
        }
    }
}
