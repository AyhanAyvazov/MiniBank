using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Interfaces;
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
    public class TransactionStatusService : ITransactionStatusService
    {
        private readonly IRepositoryBase<TransactionStatus> _transactionStatus;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionStatusService(IRepositoryBase<TransactionStatus> transactionStatus, IUnitOfWork unitOfWork)
        {
            _transactionStatus = transactionStatus;
            _unitOfWork = unitOfWork;
        }


        public async Task<InsertTransactionStatusDTO> CreateTransactionStatusAsync(InsertTransactionStatusDTO transactionStatusDto)
        {
            var transactionStatus = TransactionStatusMapping.InsertTranactionStatuesDtoToEntity(transactionStatusDto);
            await _transactionStatus.AddASync(transactionStatus, default);
            await _unitOfWork.SaveChangesAsync();
            return transactionStatusDto;
        }
    }
}
