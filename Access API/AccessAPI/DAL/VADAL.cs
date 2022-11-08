using System.Net;
using System.Text;


namespace Access_API.DAL
{
    public class VADAL
    {
        public VAResultDTO GetVAResults(string url)
        {
            string json = null;
            HttpWebResponse response = Drivers.HttpRequest.GetRequest(url);
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), Encoding.ASCII))
            {
                json = sr.ReadToEnd();
            }
            VAResultDTO vaRes = new();
            vaRes.Response = json.ToString();
            return vaRes;
        }
    }
}
