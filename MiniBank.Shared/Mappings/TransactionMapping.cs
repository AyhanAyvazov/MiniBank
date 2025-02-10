using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Roles;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Shared.DTOs.Accounts;
using MiniBank.Shared.DTOs.Roles;
using MiniBank.Shared.DTOs.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class TransactionMapping
    {
        #region Insert Mapping

        public static InsertTransactionDTO TranasactionsToInsertTransactionsDto(this Transaction transaction)
        {
            return new InsertTransactionDTO(transaction.SourceAccountId, transaction.DestinationAccountId, transaction.CurrencyId, transaction.TransactionTypeId, transaction.TransactionStatusId, transaction.Amount, transaction.TransactionExecuteTime);
        }

        public static Transaction InsertTranactionsDtoToEntity(this InsertTransactionDTO insertTransactionDto)
        {
            return new Transaction
            {
                SourceAccountId = insertTransactionDto.sourceAccountId,
                DestinationAccountId = insertTransactionDto.destionationAccountId,
                CurrencyId = insertTransactionDto.currencyId,
                TransactionTypeId = insertTransactionDto.transactionTypeid,
                TransactionStatusId = insertTransactionDto.transactionStatusId,
                Amount = insertTransactionDto.amount,
                TransactionExecuteTime = insertTransactionDto.transactionExecuteTime
            };
        }

        #endregion

        #region Update Mapping

        public static UpdateTransactionDTO TransactionUpdateAccountTypeDto(this Transaction transaction)
        {
            return new UpdateTransactionDTO(transaction.Id,transaction.TransactionStatusId);
        }

        public static void UpdateTransactionFromDto(this Transaction existing, UpdateTransactionDTO dto)
        {
           existing.TransactionStatusId = dto.transactionStatusId;
        }

        #endregion
    }
}
