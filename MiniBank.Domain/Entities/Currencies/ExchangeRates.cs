using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Currencies
{
    public class ExchangeRates : EntityBase
    {
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public double ExchangeRate { get; set; }
    }
}
