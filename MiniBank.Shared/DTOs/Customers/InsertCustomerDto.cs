using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Customers
{
    public record InsertCustomerDto(string firstName,string lastName, DateTime birthDate, string personalNumber, string mobileNumber);
}
