using Microsoft.AspNetCore.Mvc;
using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Interfaces;

namespace MiniBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DbController : ControllerBase
    {
        private readonly IRepositoryBase<Customer> _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DbController(IRepositoryBase<Customer> customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            await _customerRepository.AddASync(customer, default);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
