using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Transactions
{
    public record InsertTransactionDTO(int destionationAccountId, int currencyId, int transactionTypeid, int transactionStatusId, double amount, DateTime transactionExecuteTime);

}
