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
        public static InsertAccountTypeDTO AccountTypeToInsertDto(this AccountType accountType)
        {
            return new InsertAccountTypeDTO(accountType.Name, accountType.Description);
        }

        public static AccountType InsertDtoToAccountType(this InsertAccountTypeDTO dto)
        {
            return new AccountType
            {
                Name = dto.name,
                Description = dto.description
            };  
        }
        #endregion

        #region Update Mapping

        public static UpdateAccountTypeDTO AccountTypeToUpdateAccountTypeDto(this AccountType accountType)
        {
            return new UpdateAccountTypeDTO(accountType.Name, accountType.Description);
        }

        public static void UpdateAccountTypeFromDto(this AccountType existing, UpdateAccountTypeDTO dto)
        {
            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.UpdatedDate = DateTime.Now;
        }

        #endregion

        #region Delete Mapping
        public static DeleteAccountTypeDTO AccountTypeToDeleteDto(this AccountType accountType)
        {
            return new DeleteAccountTypeDTO(accountType.Id);
        }

        public static AccountType DeleteDtoToAccountType(this DeleteAccountTypeDTO dto)
        {
            return new AccountType { Id = dto.Id }; // Sadece ID gerekiyor
        }
        #endregion

        #region Get Mapping
        public static GetAccountTypeDTO AccountTypeToGetDto(this AccountType accountType)
        {
            return new GetAccountTypeDTO(
                accountType.Id,
                accountType.Name,
                accountType.Description,
                accountType.CreatedDate,
                accountType.UpdatedDate
            );
        }

        public static AccountType GetDtoToAccountType(this GetAccountTypeDTO dto)
        {
            return new AccountType
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate
            };
        }
        #endregion
    }
}
