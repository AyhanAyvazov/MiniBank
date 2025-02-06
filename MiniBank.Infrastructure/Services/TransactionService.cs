using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Accounts;
using MiniBank.Shared.DTOs.Transactions;
using MiniBank.Shared.Interfaces.IServices;
using MiniBank.Shared.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepositoryBase<Transaction> _transactionRepository;
        IUnitOfWork _unitOfWork;

        public TransactionService(IRepositoryBase<Transaction> transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<InsertTransactionDTO> CreateTransactionAsync(InsertTransactionDTO transactionDto)
        {
            var transaction = TransactionMapping.InsertTranactionsDtoToEntity(transactionDto);
            await _transactionRepository.AddASync(transaction, default);
            await _unitOfWork.SaveChangesAsync();
            return transactionDto;
        }

        public async Task<bool> UpdateTransactionStatustAsync(int transactionId, UpdateTransactionDTO transactionDto)
        {
            var existingTransaction = await _transactionRepository.FirstOrDefaultAsync(a => a.Id == transactionId , CancellationToken.None);
            if (existingTransaction == null)
                return false;

            existingTransaction.UpdateTransactionFromDto(transactionDto);
            await _transactionRepository.UpdateAsync(existingTransaction, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
