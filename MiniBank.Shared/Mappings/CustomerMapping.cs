using MiniBank.Domain.Entities.Customers;
using MiniBank.Shared.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class CustomerMapping
    {
        #region Insert Mapping

        public static InsertCustomerDto CustomerToInsertCustomerDto(this Customer customer)
        {
            return new InsertCustomerDto(customer.FirstName,customer.LastName, customer.BirthDate, customer.PersonalNumber, customer.MobileNumber);
        }

        public static Customer InsertCustomerDtoToEntity(this InsertCustomerDto customerDto)
        {
            return new Customer
            {
                FirstName = customerDto.firstName,
                LastName = customerDto.lastName,
                BirthDate = customerDto.birthDate,
                PersonalNumber = customerDto.personalNumber,
                MobileNumber = customerDto.mobileNumber
            };
        }

        #endregion

    }

}
