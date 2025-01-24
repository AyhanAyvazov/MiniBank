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

        public static InsertExchangeRateDTO ExchangeRateToInsertExchangeRateDto(this ExchangeRate exchangeRate)
        {
            return new InsertExchangeRateDTO(exchangeRate.FromCurrencyId, exchangeRate.ToCurrencyId, exchangeRate.Rate);
        }

        public static ExchangeRate InsertExchangeDtoToEntity(this InsertExchangeRateDTO insertExchangeRateDto)
        {
            return new ExchangeRate
            {
                FromCurrencyId = insertExchangeRateDto.fromCurrencyId,
                ToCurrencyId = insertExchangeRateDto.toCurrencyId,
                Rate = insertExchangeRateDto.rate
            };
        }

        #endregion
    }
}
