using System.Net;
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
            string query = "SELECT * WHERE { ?a ?b ?c }";

            HttpWebResponse response = Drivers.HttpRequest.GetRequest($"{Urls.RdfUrl}/{query}");

            return StatusCode((int)response.StatusCode);
        }
    }
}