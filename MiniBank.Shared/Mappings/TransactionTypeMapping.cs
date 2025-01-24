using MiniBank.Domain.Entities.Transactions;
using MiniBank.Shared.DTOs.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class TransactionTypeMapping
    {
        #region Insert Mapping

        public static InsertTransactionTypeDTO TranasactionTypesToInsertTransactionTypesDto(this TransactionType transactionType)
        {
            return new InsertTransactionTypeDTO(transactionType.Name);
        }

        public static TransactionType InsertTranactionTypesDtoToEntity(this InsertTransactionTypeDTO insertTransactionTypeDto)
        {
            return new TransactionType
            {
                Name = insertTransactionTypeDto.name
            };
        }

        #endregion
    }
}
