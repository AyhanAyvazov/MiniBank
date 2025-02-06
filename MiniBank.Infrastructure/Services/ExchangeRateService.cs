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
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IRepositoryBase<ExchangeRate> _exchangeRateRepository;
        private readonly IRepositoryBase<Currency> _currencyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExchangeRateService(
            IRepositoryBase<ExchangeRate> exchangeRateRepository,
            IRepositoryBase<Currency> currencyRepository,
            IUnitOfWork unitOfWork)
        {
            _exchangeRateRepository = exchangeRateRepository;
            _currencyRepository = currencyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InsertExchangeRateDTO> CreateExchangeRateAsync(InsertExchangeRateDTO exchangeRateDto)
        {
            // 1. FromCurrencyId ve ToCurrencyId aynı olamaz
            if (exchangeRateDto.FromCurrencyId == exchangeRateDto.ToCurrencyId)
            {
                throw new ArgumentException("FromCurrency and ToCurrency cannot be the same.");
            }

            // 2. Currency'lerin varlığını kontrol et
            var fromCurrency = await _currencyRepository.FirstOrDefaultAsync(c => c.Id == exchangeRateDto.FromCurrencyId, CancellationToken.None);
            var toCurrency = await _currencyRepository.FirstOrDefaultAsync(c => c.Id == exchangeRateDto.ToCurrencyId, CancellationToken.None);
            if (fromCurrency == null || toCurrency == null)
            {
                throw new ArgumentException("Invalid CurrencyId(s).");
            }

            // 3. Aynı döviz çifti zaten var mı?
            var existingRate = await _exchangeRateRepository.FirstOrDefaultAsync(
                er => er.FromCurrencyId == exchangeRateDto.FromCurrencyId && er.ToCurrencyId == exchangeRateDto.ToCurrencyId,
                CancellationToken.None
            );
            if (existingRate != null)
            {
                throw new ArgumentException("Exchange rate for this currency pair already exists.");
            }

            // 4. DTO → Entity dönüşümü (Mapping kullanarak)
            var exchangeRate = ExchangeRateMapping.InsertDtoToExchangeRate(exchangeRateDto);
            await _exchangeRateRepository.AddASync(exchangeRate, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();

            return exchangeRateDto;
        }

        public async Task<bool> DeleteExchangeRateAsync(DeleteExchangeRateDTO exchangeRateDto)
        {
            var exchangeRate = await _exchangeRateRepository.FirstOrDefaultAsync(er => er.Id == exchangeRateDto.Id, CancellationToken.None);
            if (exchangeRate == null) return false;

            _exchangeRateRepository.Delete(exchangeRate, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GetExchangeRateDTO>> GetAllExchangeRatesAsync()
        {
            var exchangeRates = await _exchangeRateRepository.GetAllAsync(CancellationToken.None);
            return exchangeRates.Select(er => er.ExchangeRateToGetDto());
        }

        public async Task<GetExchangeRateDTO?> GetExchangeRateByIdAsync(int exchangeRateId)
        {
            var exchangeRate = await _exchangeRateRepository.FirstOrDefaultAsync(er => er.Id == exchangeRateId, CancellationToken.None);

            // Null kontrolü ekleyerek ve extension metodunu doğru çağırarak
            return exchangeRate?.ExchangeRateToGetDto();
        }
        public async Task<bool> UpdateExchangeRateAsync(int exchangeRateId, UpdateExchangeRateDTO exchangeRateDto)
        {
            // 1. Var olan ExchangeRate'i bul
            var existing = await _exchangeRateRepository.FirstOrDefaultAsync(er => er.Id == exchangeRateId, CancellationToken.None);
            if (existing == null) return false;

            // 2. From ve To Currency'lerin varlığını kontrol et
            var fromCurrency = await _currencyRepository.FirstOrDefaultAsync(c => c.Id == exchangeRateDto.FromCurrencyId, CancellationToken.None);
            var toCurrency = await _currencyRepository.FirstOrDefaultAsync(c => c.Id == exchangeRateDto.ToCurrencyId, CancellationToken.None);
            if (fromCurrency == null || toCurrency == null)
            {
                throw new ArgumentException("Invalid CurrencyId(s).");
            }

            // 3. Aynı döviz çifti kontrolü (kendisi hariç)
            var duplicateRate = await _exchangeRateRepository.FirstOrDefaultAsync(
                er => er.FromCurrencyId == exchangeRateDto.FromCurrencyId
                   && er.ToCurrencyId == exchangeRateDto.ToCurrencyId
                   && er.Id != exchangeRateId,
                CancellationToken.None
            );
            if (duplicateRate != null)
            {
                throw new ArgumentException("Exchange rate for this currency pair already exists.");
            }

            // 4. Entity'i güncelle (Mapping kullanarak)
            existing.UpdateExchangeRateFromDto(exchangeRateDto);
            await _exchangeRateRepository.UpdateAsync(existing, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
