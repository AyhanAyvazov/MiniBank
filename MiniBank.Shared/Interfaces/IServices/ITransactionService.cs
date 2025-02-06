using MiniBank.Shared.DTOs.Accounts;
using MiniBank.Shared.DTOs.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface ITransactionService
    {
        Task<InsertTransactionDTO> CreateTransactionAsync(InsertTransactionDTO transactionDto);
        Task<bool> UpdateTransactionStatustAsync(int transactionId, UpdateTransactionDTO transactionDto);
    }
}
