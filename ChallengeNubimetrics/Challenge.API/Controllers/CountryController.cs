using Challenge.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countriesService;

        public CountryController(ICountryService countriesService)
        {
            this.countriesService = countriesService;
        }
        [HttpGet]
        [Route("Paises/{code}")]
        public async Task<IActionResult> Paises(string code)
        {
            var response = await countriesService.GetCountriesByCode(code);
            return Ok(response);
        }
    }
}
