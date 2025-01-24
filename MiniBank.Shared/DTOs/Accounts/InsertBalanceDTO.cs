using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Currencies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Accounts
{
    public record InsertBalanceDTO(int accountId, int currencyId, double amount);

}
