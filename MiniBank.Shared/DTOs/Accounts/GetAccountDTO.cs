using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Accounts
{
    public record GetAccountDTO(int id, int customerId, int accountTypeId, int accountCurrencyId, int accountNumber, bool isLocked);
    }
