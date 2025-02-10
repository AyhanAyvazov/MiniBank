using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.API.Filters;
using MiniBank.Shared.DTOs.Transactions;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeController(ITransactionTypeService transactionTypeService)
        {
            _transactionTypeService = transactionTypeService;
        }

        [HttpPost("CreateTransactionType")]
        public async Task<IActionResult> CreateTransactionType(InsertTransactionTypeDTO transactionTypeDto)
        {
            var result = await _transactionTypeService.CreateTransactionTypeAsync(transactionTypeDto);
            return Ok(result);
        }
    }
}
