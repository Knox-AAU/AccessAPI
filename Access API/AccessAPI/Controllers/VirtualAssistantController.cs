using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Access_API.BLL;

namespace Access_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox Virtual Assistant")]
    public class VirtualAssistantController : Controller
    {
        readonly VABLL VAb = new();

        [HttpGet]
        [Route("node")]
        public string GetNode([FromQuery] string id)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(VAb.vaBLL_getNode(id).Response);
                HttpContext.Response.StatusCode = 200;
            }
            catch
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
                result = JsonConvert.SerializeObject(VAb.vaBLL_getNodes(id).Response);
                HttpContext.Response.StatusCode = 200;
            }
            catch
            {
                HttpContext.Response.StatusCode = 500;
            }
            return result;
        }


    }
}
