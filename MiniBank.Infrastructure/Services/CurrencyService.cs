using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Currencies;
using MiniBank.Shared.Interfaces.IServices;
using MiniBank.Shared.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IRepositoryBase<Currency> _currencyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IRepositoryBase<Currency> currencyRepository, IUnitOfWork unitOfWork)
        {
            _currencyRepository = currencyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InsertCurrencyDTO> CreateCurrencyAsync(InsertCurrencyDTO currencyDto)
        {
            // Code'un benzersiz olduğunu kontrol et (FirstOrDefault ile)
            var existingCurrency = await _currencyRepository.FirstOrDefaultAsync(c => c.Code == currencyDto.Code, CancellationToken.None);
            if (existingCurrency != null)
            {
                throw new ArgumentException("Currency code must be unique.");
            }

            var currency = currencyDto.InsertDtoToCurrency();
            await _currencyRepository.AddASync(currency, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return currencyDto;
        }

        public async Task<bool> DeleteCurrencyAsync(DeleteCurrencyDTO currencyDto)
        {
            var currency = await _currencyRepository.FirstOrDefaultAsync(c => c.Id == currencyDto.Id, CancellationToken.None);
            if (currency == null) return false;

            _currencyRepository.Delete(currency, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GetCurrencyDTO>> GetAllCurrenciesAsync()
        {
            var currencies = await _currencyRepository.GetAllAsync(CancellationToken.None);
            return currencies.Select(c => c.CurrencyToGetDto());
        }

        public async Task<GetCurrencyDTO?> GetCurrencyByIdAsync(int currencyId)
        {
            var currency = await _currencyRepository.FirstOrDefaultAsync(c => c.Id == currencyId, CancellationToken.None);
            return currency?.CurrencyToGetDto();
        }

        public async Task<bool> UpdateCurrencyAsync(int currencyId, UpdateCurrencyDTO currencyDto)
        {
            var existing = await _currencyRepository.FirstOrDefaultAsync(c => c.Id == currencyId, CancellationToken.None);
            if (existing == null) return false;

            // Code'un benzersizliğini kontrol et (kendisi hariç)
            var duplicateCurrency = await _currencyRepository.FirstOrDefaultAsync(
                c => c.Code == currencyDto.Code && c.Id != currencyId,
                CancellationToken.None
            );
            if (duplicateCurrency != null)
            {
                throw new ArgumentException("Currency code must be unique.");
            }

            existing.UpdateCurrencyFromDto(currencyDto);
            await _currencyRepository.UpdateAsync(existing, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
