using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Currencies
{
    public record GetCurrencyDTO(
      int Id,
      string Code,
      string Name,
      string Symbol,
      DateTime CreatedDate,
      DateTime? UpdatedDate
  );
}
