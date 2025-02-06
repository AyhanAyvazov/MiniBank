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
    public static class AccountMapping
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

        #region Update Mapping
        public static UpdateAccountDTO AccountToUpdateAccountDto(this Account account)
        {
            return new UpdateAccountDTO(account.AccountTypeId, account.AccountCurrencyId, account.AccountNumber, account.IsLocked);
        }
                
        public static void UpdateAccountFromDto(this Account existingAccount, UpdateAccountDTO accountDto)
        {
            existingAccount.AccountTypeId = accountDto.accountTypeId;
            existingAccount.AccountCurrencyId = accountDto.accountCurrencyId;
            existingAccount.AccountNumber = accountDto.accountNumber;
            existingAccount.IsLocked = accountDto.isLocked;
            existingAccount.UpdatedDate = DateTime.Now;
        }

        #endregion

        #region Delete Mapping
        public static DeleteAccountDTO AccountToDeleteAccountDto(this Account account)
        {
            return new DeleteAccountDTO(account.Id);
        }

        public static Account DeleteAccountDtoToEntity(this DeleteAccountDTO accountDto)
        {
            return new Account
            {
                Id = accountDto.id
            };
        }
        #endregion 

        #region Get Mapping
        public static GetAccountDTO AccountToGetAccountDto(this Account account)
        {
            return new GetAccountDTO(account.Id, account.CustomerId, account.AccountTypeId, account.AccountCurrencyId, account.AccountNumber, account.IsLocked);
        }

        public static Account GetAccountDtoToEntity(this GetAccountDTO accountDto)
        {
            return new Account
            {
                Id = accountDto.id,
                CustomerId = accountDto.customerId,
                AccountTypeId = accountDto.accountTypeId,
                AccountCurrencyId = accountDto.accountCurrencyId,
                AccountNumber = accountDto.accountNumber,
                IsLocked = accountDto.isLocked
            };
        }
        #endregion
    }
}