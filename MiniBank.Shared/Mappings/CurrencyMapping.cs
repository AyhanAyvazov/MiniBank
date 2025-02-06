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
        public static Currency InsertDtoToCurrency(this InsertCurrencyDTO dto)
        {
            return new Currency
            {
                Code = dto.Code,
                Name = dto.Name,
                Symbol = dto.Symbol
            };
        }

        public static InsertCurrencyDTO CurrencyToInsertDto(this Currency currency)
        {
            return new InsertCurrencyDTO(currency.Code, currency.Name, currency.Symbol);
        }
        #endregion

        #region Update Mapping
        public static UpdateCurrencyDTO CurrencyToUpdateDto(this Currency currency)
        {
            return new UpdateCurrencyDTO(currency.Code, currency.Name, currency.Symbol);
        }

        public static void UpdateCurrencyFromDto(this Currency existing, UpdateCurrencyDTO dto)
        {
            existing.Code = dto.Code;
            existing.Name = dto.Name;
            existing.Symbol = dto.Symbol;
            existing.UpdatedDate = DateTime.Now;
        }
        #endregion

        #region Get Mapping
        public static GetCurrencyDTO CurrencyToGetDto(this Currency currency)
        {
            return new GetCurrencyDTO(
                currency.Id,
                currency.Code,
                currency.Name,
                currency.Symbol,
                currency.CreatedDate,
                currency.UpdatedDate
            );
        }
        #endregion
    }
}
