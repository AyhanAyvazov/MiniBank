using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Infrastructure.Services;
using MiniBank.Shared.DTOs.Transactions;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionStatusController : ControllerBase
    {
        private readonly ITransactionStatusService _transactionStatusService;

        public TransactionStatusController(ITransactionStatusService transactionStatusService)
        {
            _transactionStatusService = transactionStatusService;
        }

        [HttpPost("AddTranscationStatus")]

        public async Task<IActionResult> AddTransactionStatus(InsertTransactionStatusDTO transactionStatusDto)
        {
            var result = await _transactionStatusService.CreateTransactionStatusAsync(transactionStatusDto);
            return Ok(result);
        }
    }
}
