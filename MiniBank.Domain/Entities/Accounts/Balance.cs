using MiniBank.Domain.Entities.Currencies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Accounts
{
    public class Balance : EntityBase
    {
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account? Account { get; set; }
        public int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency? Currency { get; set; }

        public double Amount { get; set; }
       
    }
}
