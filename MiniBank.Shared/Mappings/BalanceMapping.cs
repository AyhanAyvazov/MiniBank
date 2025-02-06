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

        public static Balance InsertBalanceDtoToEntity(this InsertBalanceDTO balanceDto)
        {
            return new Balance
            {
                AccountId = balanceDto.AccountId,
                CurrencyId = balanceDto.CurrencyId,
                Amount = balanceDto.Amount
            };
        }
        #endregion

            #region Update Mapping
            public static UpdateBalanceDTO BalanceToUpdateBalanceDto(this Balance balance)
            {
                return new UpdateBalanceDTO(
                    balance.AccountId,
                    balance.CurrencyId,
                    balance.Amount
                );
            }

            public static void UpdateBalanceFromDto(this Balance existing, UpdateBalanceDTO balanceDto)
            {
                existing.AccountId = balanceDto.AccountId;
                existing.CurrencyId = balanceDto.CurrencyId;
                existing.Amount = balanceDto.Amount;
                existing.UpdatedDate = DateTime.Now;
            }
            #endregion

        #region Get Mapping
        public static GetBalanceDTO BalanceToGetBalanceDto(this Balance balance)
        {
            return new GetBalanceDTO(
                balance.Id,
                balance.AccountId,
                balance.CurrencyId,
                balance.Amount,
                balance.CreatedDate,
                balance.UpdatedDate
            );
        }
        #endregion
    }
}
