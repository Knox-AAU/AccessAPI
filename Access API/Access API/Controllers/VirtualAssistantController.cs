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
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox Virtual Assistant")]
    public class VirtualAssistantController : Controller
    {
        VABLL VAb = new VABLL();

        [HttpGet]
        [Route("node")]
        public string GetNode([FromQuery] string id)
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
        [Route("nodes")]
        public string GetNodes([FromQuery] string id)
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
