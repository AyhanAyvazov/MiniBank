using MiniBank.Shared.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface IBalanceService
    {
        Task<InsertBalanceDTO> CreateBalanceAsync(InsertBalanceDTO balanceDto);
        Task<GetBalanceDTO?> GetBalanceByIdAsync(int balanceId);
        Task<IEnumerable<GetBalanceDTO>> GetAllBalancesAsync();
        Task<bool> UpdateBalanceAsync(int balanceId, UpdateBalanceDTO balanceDto); 
        Task<bool> DeleteBalanceAsync(DeleteBalanceDTO balanceDto);
    }
}
