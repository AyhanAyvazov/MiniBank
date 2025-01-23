using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Transactions
{
    public class TransactionType : EntityBase
    {
        public string Name { get; set; }
    }
}
