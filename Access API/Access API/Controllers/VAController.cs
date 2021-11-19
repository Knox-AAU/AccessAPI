using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Access_API.BLL;

namespace Access_API.Controllers
{
    [Route("api/VA")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox Virtual Assistant")]
    public class VAController : Controller
    {
        VABLL VAb = new VABLL();
        [HttpGet]
        public string Get([FromQuery] string input)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(VAb.vaBLL(input));
                HttpContext.Response.StatusCode = 200;
            }
            catch(Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
            }
            return result;
        }


        [HttpGet]
        [Route("/[controller]/getNode/{id}")]

        public string GetNode(string id)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(VAb.vaBLL_getNode(id).response);
                HttpContext.Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
            }
            return result;
        }


        [HttpGet]
        [Route("/[controller]/getNodes/{id}")]
        public string GetNodes(string id)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(VAb.vaBLL_getNodes(id).response);
                HttpContext.Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
            }
            return result;
        }


    }
}
