using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Currencies
{
    public record UpdateCurrencyDTO(string Code, string Name, string Symbol);
}

