using MiniBank.Shared.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface IAccountService
    {
         Task<InsertAccountDTO> CreateAccountAsync(InsertAccountDTO accountDto);
         Task<GetAccountDTO?> GetAccountByIdAsync(int accountId);
         Task<IEnumerable<GetAccountDTO>> GetAllAccountsAsync();
         Task<bool> UpdateAccountAsync(int accountId, UpdateAccountDTO accountDto);
         Task<bool> DeleteAccountAsync(DeleteAccountDTO accountDTO);
    }
}
