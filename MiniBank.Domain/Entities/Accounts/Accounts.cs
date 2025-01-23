using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Accounts
{
    public class Accounts : EntityBase
    {
        public int CustomerId { get; set; }
        public int AccountTypeId { get; set; }
        public int AccountCurrencyId { get; set; }
        public int AccountNumber { get; set; }
        public bool IsLocked { get; set; }

    }
}
