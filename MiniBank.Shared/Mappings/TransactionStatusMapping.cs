using MiniBank.Domain.Entities.Transactions;
using MiniBank.Shared.DTOs.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class TransactionStatusMapping
    {
        #region Insert Mapping

        public static InsertTransactionStatusDTO TranasactionStatuesToInsertTransactionStatuesDto(this TransactionStatus transaction)
        {
            return new InsertTransactionStatusDTO( transaction.Name);
        }

        public static TransactionStatus InsertTranactionStatuesDtoToEntity(this InsertTransactionStatusDTO insertTransactionStatusDto)
        {
            return new TransactionStatus
            {
                Name = insertTransactionStatusDto.name
            };
        }

        #endregion
    }
}
