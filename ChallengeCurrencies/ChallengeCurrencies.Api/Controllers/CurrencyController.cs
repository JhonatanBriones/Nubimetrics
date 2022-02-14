using ChallengeCurrencies.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeCurrencies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }
        [HttpGet]
        public async Task<IActionResult> Currency()
        {
            try
            {
                var response = await currencyService.GetCurrencies();
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new
                {
                    success=false,
                    message=ex.Message,
                    data=ex.StackTrace
                };
                return BadRequest(error);
            }
            
        }
    }
}
