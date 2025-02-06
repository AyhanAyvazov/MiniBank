    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Accounts
{
    public record GetBalanceDTO(int Id, int AccountId, int CurrencyId, double Amount, DateTime CreatedDate, DateTime? UpdatedDate);

}
