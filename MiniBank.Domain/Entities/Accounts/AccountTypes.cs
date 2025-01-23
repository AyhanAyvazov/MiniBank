using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Accounts
{
    public class AccountTypes : EntityBase
    {  
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
