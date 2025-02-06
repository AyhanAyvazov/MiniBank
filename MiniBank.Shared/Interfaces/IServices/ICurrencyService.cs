using MiniBank.Shared.DTOs.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface ICurrencyService
    {
        Task<InsertCurrencyDTO> CreateCurrencyAsync(InsertCurrencyDTO currencyDto);
        Task<GetCurrencyDTO?> GetCurrencyByIdAsync(int currencyId);
        Task<IEnumerable<GetCurrencyDTO>> GetAllCurrenciesAsync();
        Task<bool> UpdateCurrencyAsync(int currencyId, UpdateCurrencyDTO currencyDto);
        Task<bool> DeleteCurrencyAsync(DeleteCurrencyDTO currencyDto);
    }
}
