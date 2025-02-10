using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.API.Filters;
using MiniBank.Shared.DTOs.Accounts;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;

        public AccountTypeController(IAccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;

        }

        [HttpPost("CreateAccountType")]
        public async Task<IActionResult> CreateAccountType(InsertAccountTypeDTO accountTypeDto)
        {
            var result = await _accountTypeService.CreateAccountTypeAsync(accountTypeDto);
            return Ok(result);
        }

        [HttpGet("GetAccountTypeById/{accountTypeId}")]
        public async Task<IActionResult> GetAccountTypeById(int accountTypeId)
        {
            var result = await _accountTypeService.GetAccountTypeByIdAsync(accountTypeId);
            return Ok(result);
        }

        [HttpGet("GetAllAccountTypes")]
        public async Task<IActionResult> GetAllAccountTypes()
        {
            var result = await _accountTypeService.GetAllAccountTypesAsync();
            return Ok(result);
        }

        [HttpPut("UpdateAccountType/{accountTypeId}")]
        public async Task<IActionResult> UpdateAccountType(int accountTypeId, UpdateAccountTypeDTO accountTypeDto)
        {
            var result = await _accountTypeService.UpdateAccountTypeAsync(accountTypeId, accountTypeDto);
            return Ok(result);
        }


        [HttpDelete("DeleteAccountType/{accountTypeId}")]
        public async Task<IActionResult> DeleteAccountType(DeleteAccountTypeDTO accountTypeDTO)
        {
            var result = await _accountTypeService.DeleteAccountTypeAsync(accountTypeDTO);
            return Ok(result);
        }


    }
}
