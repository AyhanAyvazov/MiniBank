using MiniBank.Shared.DTOs.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface ITransactionStatusService
    {
        Task<InsertTransactionStatusDTO> CreateTransactionStatusAsync(InsertTransactionStatusDTO transactionStatusDto);
    }
}
