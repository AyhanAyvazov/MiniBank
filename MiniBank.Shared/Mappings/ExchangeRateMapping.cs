using MiniBank.Domain.Entities.Currencies;
using MiniBank.Shared.DTOs.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class ExchangeRateMapping
    {
        #region Insert Mapping
        public static ExchangeRate InsertDtoToExchangeRate(this InsertExchangeRateDTO dto)
        {
            return new ExchangeRate
            {
                FromCurrencyId = dto.FromCurrencyId,
                ToCurrencyId = dto.ToCurrencyId,
                Rate = dto.Rate
            };
        }

        public static InsertExchangeRateDTO ExchangeRateToInsertDto(this ExchangeRate exchangeRate)
        {
            return new InsertExchangeRateDTO(
                exchangeRate.FromCurrencyId,
                exchangeRate.ToCurrencyId,
                exchangeRate.Rate
            );
        }
        #endregion

        #region Update Mapping
        public static UpdateExchangeRateDTO ExchangeRateToUpdateDto(this ExchangeRate exchangeRate)
        {
            return new UpdateExchangeRateDTO(
                exchangeRate.FromCurrencyId,
                exchangeRate.ToCurrencyId,
                exchangeRate.Rate
            );
        }

        public static void UpdateExchangeRateFromDto(this ExchangeRate existing, UpdateExchangeRateDTO dto)
        {
            existing.FromCurrencyId = dto.FromCurrencyId;
            existing.ToCurrencyId = dto.ToCurrencyId;
            existing.Rate = dto.Rate;
            existing.UpdatedDate = DateTime.Now;
        }
        #endregion

        #region Get Mapping
        public static GetExchangeRateDTO ExchangeRateToGetDto(this ExchangeRate exchangeRate)
        {
            return new GetExchangeRateDTO(
                exchangeRate.Id,
                exchangeRate.FromCurrencyId,
                exchangeRate.ToCurrencyId,
                exchangeRate.Rate,
                exchangeRate.CreatedDate,
                exchangeRate.UpdatedDate
            );
        }
        #endregion
    }
}
