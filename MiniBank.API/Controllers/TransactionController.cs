using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.API.Filters;
using MiniBank.Shared.DTOs.Customers;
using MiniBank.Shared.DTOs.Transactions;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("AddTranscation")]

        public async Task<IActionResult> AddTransaction(InsertTransactionDTO transactionDto)
        {
            var result = await _transactionService.CreateTransactionAsync(transactionDto);
            return Ok(result);
        }
    }
}

