using MiniBank.Shared.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface IAccountTypeService
    {
        Task<InsertAccountTypeDTO> CreateAccountTypeAsync(InsertAccountTypeDTO accountTypeDto);
        Task<GetAccountTypeDTO?> GetAccountTypeByIdAsync(int id);
        Task<IEnumerable<GetAccountTypeDTO>> GetAllAccountTypesAsync();
        Task<bool> UpdateAccountTypeAsync(int accountTypeId, UpdateAccountTypeDTO accountTypeDto);
        Task<bool> DeleteAccountTypeAsync(DeleteAccountTypeDTO accountTypeDto);
    }
}
