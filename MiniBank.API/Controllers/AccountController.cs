using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Infrastructure.Services;
using MiniBank.Shared.DTOs.Accounts;
using MiniBank.Shared.DTOs.Customers;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("RegisterAccount")]

        public async Task<IActionResult> RegisterAccount(InsertAccountDTO accountDto)
        {
            var result = await _accountService.CreateAccountAsync(accountDto);
            return Ok(result);
        }

        [HttpGet("GetAccountById/{accountId}")]

        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var result = await _accountService.GetAccountByIdAsync(accountId);
            return Ok(result);
        }

        [HttpGet("GetAllAccounts")]

        public async Task<IActionResult> GetAllAccounts()
        {
            var result = await _accountService.GetAllAccountsAsync();
            return Ok(result);
        }

        [HttpPut("UpdateAccount/{accountId}")]
        public async Task<IActionResult> UpdateAccount(int accountId, UpdateAccountDTO accountDto)
        {
            var result = await _accountService.UpdateAccountAsync(accountId, accountDto);
            return Ok(result);
        }

        [HttpDelete("DeleteAccount/{accountId}")]
        public async Task<IActionResult> DeleteAccount(DeleteAccountDTO accountDTO)
        {
            var result = await _accountService.DeleteAccountAsync(accountDTO);
            return Ok(result);
        }
    }
}
