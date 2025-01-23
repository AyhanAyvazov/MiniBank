using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Transactions
{
    public class Transactions : EntityBase
    {
        public int SourceAccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public int CurrencyId { get; set; }
        public int TransactionTypeId { get; set; }
        public int TransactionStatusId { get; set; }

        public double Amount { get; set; } 
        public DateTime TransactionExecuteTime  { get; set; } 
    }
}
