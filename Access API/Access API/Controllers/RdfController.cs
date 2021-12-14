using Access_API.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Access_API.Controllers
{
    [Route("api/rdf")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox RDF endpoints")]
    public sealed class RdfController : Controller
    {
        [HttpGet]
        [Route("status")]
        public IActionResult GetStatus()
        {
            const string query = "SELECT * WHERE { ?a ?b ?c }";

            DatabasePingBLL bll = new DatabasePingBLL();
            var response = bll.PingDatabase(query);
            return StatusCode((int)response.StatusCode);
        }
    }
}