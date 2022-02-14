using Challenge.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService service;

        public SearchController(ISearchService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("busqueda/{query}")]
        public async Task<IActionResult> Busqueda(string query)
        {
            var response= await service.ShearchByQuery(query);
            return Ok(response);
        }
    }
}
