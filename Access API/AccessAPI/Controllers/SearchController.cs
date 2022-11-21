using System;
using System.Collections.Generic;
using System.Net.Mime;
using Access_API.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Access_API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox search endpoints")]
    [Route("api/search")]
    [Produces(MediaTypeNames.Application.Json)]
    public class SearchController : ControllerBase
    {
        readonly BLL.SearchBLL _sb = new();

        [HttpGet] // 127.0.0.1:8081/api/search?words=test&sourceId=1&author=bob&categoryId=2
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Get([FromQuery] string words, [FromQuery] int? sourceId, [FromQuery] string? author,
            [FromQuery] int? categoryId, [FromQuery] DateTime? beforeDate, [FromQuery] DateTime? afterDate)
        {
            try
            {
                return Ok(_sb.SearchBll(words, sourceId, author, categoryId, beforeDate, afterDate));
            }
            catch (SearchQueryResponseException e)
            {
                return Problem(e.ErrorResponse.Title);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet] // 127.0.0.1:8081/api/search/categories
        [Route("/categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<string>> GetAllCategories([FromQuery] int? limit, [FromQuery] int? offset)
        {
            try
            {
                return Ok(_sb.CategoriesBll(limit, offset));
            }
            catch (SearchQueryResponseException e)
            {
                return Problem(e.ErrorResponse.Title);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        
        [HttpGet] // 127.0.0.1:8081/api/search/sources
        [Route("/sources")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<string>> GetAllSources([FromQuery] int? limit, [FromQuery] int? offset)
        {
            try
            {
                return Ok(_sb.SourcesBll(limit, offset));
            }
            catch (SearchQueryResponseException e)
            {
                return Problem(e.ErrorResponse.Title);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
