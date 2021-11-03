using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access_API.DAL;

namespace Access_API.BLL
{
    public class VABLL
    {
        public VAResultsDTO vaBLL(string input)
        {
            string url = Urls.VAUrl + $"/VA?input={input}";
            VADAL DAL = new VADAL();

            return DAL.GetVAResults(url);
        }
    }
}
