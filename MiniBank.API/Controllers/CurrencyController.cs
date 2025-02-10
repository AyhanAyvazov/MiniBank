using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.API.Filters;
using MiniBank.Shared.DTOs.Currencies;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurrency(InsertCurrencyDTO currencyDto)
        {
            var result = await _currencyService.CreateCurrencyAsync(currencyDto);
            return Ok(result);
        }

        [HttpGet("{currencyId}")]
        public async Task<IActionResult> GetCurrency(int currencyId)
        {
            var result = await _currencyService.GetCurrencyByIdAsync(currencyId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var result = await _currencyService.GetAllCurrenciesAsync();
            return Ok(result);
        }

        [HttpPut("UpdateCurrency/{currencyId}")]
        public async Task<IActionResult> UpdateCurrency(int currencyId, UpdateCurrencyDTO currencyDto)
        {
            var result = await _currencyService.UpdateCurrencyAsync(currencyId, currencyDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCurrency(DeleteCurrencyDTO currencyDto)
        {
            var result = await _currencyService.DeleteCurrencyAsync(currencyDto);
            return Ok(result);
        }
    }
}
