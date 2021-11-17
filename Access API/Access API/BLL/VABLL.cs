using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access_API.DAL;

namespace Access_API.BLL
{
    public class VABLL
    {
        public VAResultDTO vaBLL(string input)
        {
            string url = Urls.vaUrl + $"/VA?input={input}";
            VADAL DAL = new VADAL();

            return DAL.GetVAResults(url);
        }

        public VAResultDTO vaBLL_getNode(string input)
        {
            string url = Urls.vaUrl + $"/getNode/{input}";
            
            VADAL DAL = new VADAL();

            return DAL.GetVAResults(url);
        }

        public VAResultDTO vaBLL_getNodes(string input)
        {
            string url = Urls.vaUrl + $"/KnowledgeGraph/getNodes/{input}";
            VADAL DAL = new VADAL();

            var res =  DAL.GetVAResults(url);
            return res;
        }
    }
}
