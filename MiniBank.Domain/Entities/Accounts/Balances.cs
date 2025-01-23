using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Accounts
{
    public class Balances : EntityBase
    {
        public int AccountId { get; set; }
        public int CurrencyId { get; set; }

        public double Amount { get; set; }
       
    }
}
