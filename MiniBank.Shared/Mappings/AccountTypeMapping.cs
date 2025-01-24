using MiniBank.Domain.Entities.Accounts;
using MiniBank.Shared.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class AccountTypeMapping
    {
        #region Insert Mapping

        public static InsertAccountTypeDTO AccountTypeToInsertAccountTypeDto(this AccountType accountType)
        {
            return new InsertAccountTypeDTO(accountType.Name, accountType.Description);
        }

        public static AccountType InsertAccountTypeDtoToEntity(this InsertAccountTypeDTO accountTypeDto)
        {
            return new AccountType
            {
                Name = accountTypeDto.name,
                Description = accountTypeDto.description
            };
        }

        #endregion
    }
}
