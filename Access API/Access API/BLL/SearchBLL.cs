using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Access_API.BLL
{
    public class SearchBLL
    {
        public SearchResults searchBLL(string input, string sources)
        {
            // 127.0.0.1:8081/search?input=test&sources=Nordjyske,Grundfoss
            string url = $"127.0.0.1:8081/search?input={input}&sources={sources}";
            DAL.SearchDAL DAL = new DAL.SearchDAL();

            return DAL.searchDAL(url);
        }
    }
}
