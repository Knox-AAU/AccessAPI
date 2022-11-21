using System;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using Access_API.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Access_API.DAL
{
    public class DocumentDataDAL
    {
        public string GetResults(string url)
        {
            string json = String.Empty;
            HttpWebResponse response = Drivers.HttpRequest.GetRequest(url);
            if (response.StatusCode is HttpStatusCode.OK or HttpStatusCode.InternalServerError)
            {
                using System.IO.StreamReader sr =
                    new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                json = sr.ReadToEnd();

                if (response.StatusCode is HttpStatusCode.InternalServerError)
                {
                    ProblemDetailsDTO error = JsonConvert.DeserializeObject<ProblemDetailsDTO>(json)!;
                    throw new ApiResponseException(error);
                }
            }
            else if (response.StatusCode is HttpStatusCode.NotFound)
            {
                json = "[]";
            }

            return json;

            // SearchResultsDTO results = JsonConvert.DeserializeObject<SearchResultsDTO>(json)!;
        }
    }
}
