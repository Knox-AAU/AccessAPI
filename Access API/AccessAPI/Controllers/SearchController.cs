using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Access_API.Controllers
{
    [Route("api/search")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox search endpoints")]
    public class SearchController : ControllerBase
    {
        readonly BLL.SearchBLL _sb = new();
        [HttpGet]       // 127.0.0.1:8081/api/search?input=test&sources=Nordjyske,Grundfoss
        public string Get([FromQuery] string input, [FromQuery] string sources)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(_sb.searchBLL(input, sources));
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
