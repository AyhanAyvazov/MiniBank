using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Currencies
{
    public class ExchangeRate : EntityBase
    {
        public int FromCurrencyId { get; set; }
        [ForeignKey("FromCurrencyId")]
        public Currency? FromCurrency { get; set; }
        public int ToCurrencyId { get; set; }
        [ForeignKey("ToCurrencyId")]
        public Currency? ToCurrency { get; set; }
        public double Rate { get; set; }
    }
}
