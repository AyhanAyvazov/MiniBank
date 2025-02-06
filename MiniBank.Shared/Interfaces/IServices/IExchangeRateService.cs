using MiniBank.Shared.DTOs.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface IExchangeRateService
    {
        Task<InsertExchangeRateDTO> CreateExchangeRateAsync(InsertExchangeRateDTO exchangeRateDto);
        Task<GetExchangeRateDTO?> GetExchangeRateByIdAsync(int exchangeRateId);
        Task<IEnumerable<GetExchangeRateDTO>> GetAllExchangeRatesAsync();
        Task<bool> UpdateExchangeRateAsync(int exchangeRateId, UpdateExchangeRateDTO exchangeRateDto);
        Task<bool> DeleteExchangeRateAsync(DeleteExchangeRateDTO exchangeRateDto);
    }
}
