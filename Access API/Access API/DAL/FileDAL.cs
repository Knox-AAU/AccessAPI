using System;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Access_API.DAL
{
    public class FileDAL
    {
        public List<byte> fileDAL(int id) 
        {
            List<byte> bytes = new List<byte>();

            HttpWebResponse response = Drivers.HttpRequest.getRequest($"http://localhost:8081/api/test");
            if(true /*response.ContentType == "PDF"*/) 
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        sr.BaseStream.CopyTo(ms);
                        byte[] b = new byte[ms.Length];
                        b = ms.ToArray();
                        bytes.AddRange(b);
                    }
                }
            }
            return bytes;
        }
    }
}
