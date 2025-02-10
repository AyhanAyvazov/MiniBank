using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.API.Filters;
using MiniBank.Infrastructure.Services;
using MiniBank.Shared.DTOs.Accounts;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class BalanceController : ControllerBase
    {

        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

            [HttpPost("CreateBalance")]
        public async Task<IActionResult> CreateBalance(InsertBalanceDTO balanceDto)
        {
            var result = await _balanceService.CreateBalanceAsync(balanceDto);
            return Ok(result);
        }

        [HttpGet("GetBalanceById/{balanceId}")]
        public async Task<IActionResult> GetBalanceById(int balanceId)
        {
            var result = await _balanceService.GetBalanceByIdAsync(balanceId);
            return Ok(result);
        }

        [HttpGet("GetAllBalances")]
        public async Task<IActionResult> GetAllBalances()
        {
            var result = await _balanceService.GetAllBalancesAsync();
            return Ok(result);
        }

        [HttpPut("UpdateBalance/{balanceId}")]
        public async Task<IActionResult> UpdateBalance(int balanceId, UpdateBalanceDTO balanceDto)
        {
            var result = await _balanceService.UpdateBalanceAsync(balanceId, balanceDto); 
            return Ok(result);
        }

        [HttpDelete("DeleteBalance/{balanceId}")]

        public async Task<IActionResult> DeleteBalance(DeleteBalanceDTO balanceDTO)
        {
            var result = await _balanceService.DeleteBalanceAsync(balanceDTO);
            return Ok(result);
        }

    }
}
