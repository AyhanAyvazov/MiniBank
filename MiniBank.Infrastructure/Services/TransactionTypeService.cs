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
using System.Transactions;

namespace MiniBank.Infrastructure.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly IRepositoryBase<TransactionType> _transactionTypeService;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionTypeService(IRepositoryBase<TransactionType> transactionTypeService, IUnitOfWork unitOfWork)
        {
            _transactionTypeService = transactionTypeService;
            _unitOfWork = unitOfWork;

        }

       public async Task<InsertTransactionTypeDTO> CreateTransactionTypeAsync(InsertTransactionTypeDTO transactionTypeDto)
        {
            var transactionType = TransactionTypeMapping.InsertTranactionTypesDtoToEntity(transactionTypeDto);
            await _transactionTypeService.AddASync(transactionType, default);
            await _unitOfWork.SaveChangesAsync();
            return transactionTypeDto;
        }

    }
}
