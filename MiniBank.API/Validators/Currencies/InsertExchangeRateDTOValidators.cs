using FluentValidation;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Currencies;

namespace MiniBank.API.Validators.Currencies
{
    public class InsertExchangeRateDTOValidator : AbstractValidator<InsertExchangeRateDTO>
    {
        private readonly IRepositoryBase<Currency> _currencyRepository;
        private readonly IRepositoryBase<ExchangeRate> _exchangeRateRepository;

        public InsertExchangeRateDTOValidator(
            IRepositoryBase<Currency> currencyRepository,
            IRepositoryBase<ExchangeRate> exchangeRateRepository)
        {
            _currencyRepository = currencyRepository;
            _exchangeRateRepository = exchangeRateRepository;

            RuleFor(x => x.Rate)
                .GreaterThan(0)
                .WithMessage("Exchange rate must be a positive number.");

            RuleFor(x => x.FromCurrencyId)
                .MustAsync(async (currencyId, cancellationToken) =>
                {
                    var currency = await _currencyRepository.FirstOrDefaultAsync(c => c.Id == currencyId && !c.IsDeleted, cancellationToken);
                    return currency != null;
                }).WithMessage("FromCurrencyId must be an existing and active currency.");

            RuleFor(x => x.ToCurrencyId)
                .MustAsync(async (currencyId, cancellationToken) =>
                {
                    var currency = await _currencyRepository.FirstOrDefaultAsync(c => c.Id == currencyId && !c.IsDeleted, cancellationToken);
                    return currency != null;
                }).WithMessage("ToCurrencyId must be an existing and active currency.");

            RuleFor(x => x)
                .Must(x => x.FromCurrencyId != x.ToCurrencyId)
                .WithMessage("FromCurrencyId and ToCurrencyId must be different.");

            RuleFor(x => x)
                .MustAsync(async (dto, cancellationToken) =>
                {
                    var existingRate = await _exchangeRateRepository.FirstOrDefaultAsync(
                        e => e.FromCurrencyId == dto.FromCurrencyId && e.ToCurrencyId == dto.ToCurrencyId,
                        cancellationToken);
                    return existingRate == null;
                }).WithMessage("An exchange rate already exists for the given currency pair.");
        }
    }
}
