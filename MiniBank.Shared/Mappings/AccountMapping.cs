using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Customers;
using MiniBank.Shared.DTOs.Accounts;
using MiniBank.Shared.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class AccountMapper
    {
        #region Insert Mapping

        public static InsertAccountDTO AccountToInsertAccountDto(this Account account)
        {
            return new InsertAccountDTO(account.CustomerId, account.AccountTypeId, account.AccountCurrencyId, account.AccountNumber);
        }

        public static Account InsertAccountDtoToEntity(this InsertAccountDTO accountDto)
        {
            return new Account
            {
                CustomerId = accountDto.customerID,
                AccountTypeId = accountDto.accountTypeId,
                AccountCurrencyId = accountDto.accountCurrencyId,
                AccountNumber = accountDto.accountNumber
            };
        }

        #endregion
    }
}
