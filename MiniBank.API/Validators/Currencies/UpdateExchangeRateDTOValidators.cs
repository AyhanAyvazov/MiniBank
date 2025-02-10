using FluentValidation;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Currencies;

namespace MiniBank.API.Validators.Currencies
{
    public class UpdateExchangeRateDTOValidator : AbstractValidator<UpdateExchangeRateDTO>
    {
        private readonly IRepositoryBase<ExchangeRate> _exchangeRateRepository;

        public UpdateExchangeRateDTOValidator(IRepositoryBase<ExchangeRate> exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;

            RuleFor(x => x.Rate)
                .GreaterThan(0)
                .WithMessage("Exchange rate must be a positive number.");

            RuleFor(x => x)
                .MustAsync(async (dto, cancellationToken) =>
                {
                    var existingRate = await _exchangeRateRepository.FirstOrDefaultAsync(
                        e => e.FromCurrencyId == dto.FromCurrencyId && e.ToCurrencyId == dto.ToCurrencyId, cancellationToken);

                    if (existingRate == null)
                        return false;

                    double allowedPercentageChange = 0.1; 
                    double maxAllowedRate = existingRate.Rate * (1 + allowedPercentageChange);
                    double minAllowedRate = existingRate.Rate * (1 - allowedPercentageChange);

                    return dto.Rate >= minAllowedRate && dto.Rate <= maxAllowedRate;
                }).WithMessage("The exchange rate change exceeds the allowed percentage limit.");
        }
    }
}
