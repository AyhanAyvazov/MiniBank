using MiniBank.Domain.Entities.Currencies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Currencies
{
    public record InsertExchangeRateDTO(int FromCurrencyId, int ToCurrencyId, double Rate);


}
