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
        public SearchResultsDTO searchBLL(string input, string sources)
        {
            string url = $"http://localhost:3030/search?input={input}&sources={sources}";
            DAL.SearchDAL DAL = new DAL.SearchDAL();

            return DAL.searchDAL(url);
        }
    }
}
