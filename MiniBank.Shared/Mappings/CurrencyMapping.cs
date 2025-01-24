using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Shared.DTOs.Accounts;
using MiniBank.Shared.DTOs.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class CurrencyMapping
    {
        #region Insert Mapping

        public static InsertCurrencyDTO CurrencyToInsertCurrencyDto(this Currency currency)
        {
            return new InsertCurrencyDTO(currency.Code, currency.Name, currency.Symbol);
        }

        public static Currency InsertCurrencyDtoToEntity(this InsertCurrencyDTO insertCurrencyDto)
        {
            return new Currency
            {
                Code = insertCurrencyDto.code,
                Name = insertCurrencyDto.name,
                Symbol = insertCurrencyDto.symbol
            };
        }

        #endregion
    }
}
