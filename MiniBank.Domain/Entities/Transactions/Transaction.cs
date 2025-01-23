using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Currencies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Transactions
{
    public class Transaction : EntityBase
    {
        public int SourceAccountId { get; set; }
        [ForeignKey("SourceAccountId")]
        public Account? SourceAccount { get; set; }
        public int DestinationAccountId { get; set; }
        [ForeignKey("DestinationAccountId")]
        public Account? DestinationAccount { get; set; }
        public int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency? Currency { get; set; }
        public int TransactionTypeId { get; set; }
        [ForeignKey("TransactionTypeId")]
        public TransactionType? TransactionType { get; set; }
        public int TransactionStatusId { get; set; }
        [ForeignKey("TransactionStatusId")]
        public TransactionStatus? TransactionStatus { get; set; }

        public double Amount { get; set; } 
        public DateTime TransactionExecuteTime  { get; set; } 
    }
}
