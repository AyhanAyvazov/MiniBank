using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Currencies
{
    public record GetExchangeRateDTO(
     int Id,
     int FromCurrencyId,
     int ToCurrencyId,
     double Rate,
     DateTime CreatedDate,
     DateTime? UpdatedDate
 );
}
