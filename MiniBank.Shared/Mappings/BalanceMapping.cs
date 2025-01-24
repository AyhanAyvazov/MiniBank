using MiniBank.Domain.Entities.Accounts;
using MiniBank.Shared.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class BalanceMapping
    {
        #region Insert Mapping

        public static InsertBalanceDTO BalanceToInsertBalanceDto(this Balance balance)
        {
            return new InsertBalanceDTO(balance.AccountId, balance.CurrencyId, balance.Amount);
        }

        public static Balance InsertBalanceDtoToEntity(this InsertBalanceDTO accountTypeDto)
        {
            return new Balance
            {
                AccountId = accountTypeDto.accountId,
                CurrencyId = accountTypeDto.currencyId,
                Amount = accountTypeDto.amount
            };
        }

        #endregion
    }
}
