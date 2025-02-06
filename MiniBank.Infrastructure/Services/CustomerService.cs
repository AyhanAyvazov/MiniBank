using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Interfaces;
using MiniBank.Persistence.Repositories;
using MiniBank.Shared.DTOs.Customers;
using MiniBank.Shared.Interfaces.IServices;
using MiniBank.Shared.Mappings;

namespace MiniBank.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        IRepositoryBase<Customer> _customerRepository;
        IUnitOfWork _unitOfWork;
        public CustomerService(IRepositoryBase<Customer> customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InsertCustomerDto> CreateCustomer(InsertCustomerDto customerDto)
        {
            var customer = CustomerMapping.InsertCustomerDtoToEntity(customerDto);
            await _customerRepository.AddASync(customer, default);
            await _unitOfWork.SaveChangesAsync();
            return customerDto;  
        }
    }
}
    