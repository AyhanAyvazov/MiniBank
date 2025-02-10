using FluentValidation;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Currencies;

namespace MiniBank.API.Validators.Currencies
{
    public class DeleteCurrencyDTOValidator : AbstractValidator<DeleteCurrencyDTO>
    {
        private readonly IRepositoryBase<Balance> _balanceRepository;
        private readonly IRepositoryBase<ExchangeRate> _exchangeRateRepository;

        public DeleteCurrencyDTOValidator(
            IRepositoryBase<Balance> balanceRepository,
            IRepositoryBase<ExchangeRate> exchangeRateRepository)
        {
            _balanceRepository = balanceRepository;
            _exchangeRateRepository = exchangeRateRepository;

            RuleFor(x => x.Id)
                .MustAsync(async (currencyId, cancellationToken) =>
                {
                    var balances = await _balanceRepository.GetByAsync(b => b.CurrencyId == currencyId, cancellationToken);
                    return !balances.Any();
                }).WithMessage("Currency cannot be deleted as there are existing balances.");

            RuleFor(x => x.Id)
                .MustAsync(async (currencyId, cancellationToken) =>
                {
                    var exchangeRates = await _exchangeRateRepository.GetByAsync(e => e.FromCurrencyId == currencyId || e.ToCurrencyId == currencyId, cancellationToken);
                    return !exchangeRates.Any();
                }).WithMessage("Currency cannot be deleted as it is used in active exchange rates.");
        }
    }
}
