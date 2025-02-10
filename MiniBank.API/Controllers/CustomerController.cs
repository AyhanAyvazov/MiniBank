using Microsoft.AspNetCore.Mvc;
using MiniBank.API.Filters;
using MiniBank.Shared.DTOs.Customers;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilter))]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("RegisterCustomer")]

        public async Task<IActionResult> RegisterCustomer(InsertCustomerDto customerDto)
        {
            var result = await _customerService.CreateCustomer(customerDto);
            return Ok(result);
        }
    }
}
