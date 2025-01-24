using MiniBank.Shared.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface ICustomerService
    {
        Task<InsertCustomerDto> CreateCustomer(InsertCustomerDto customerDto);
    }
}
