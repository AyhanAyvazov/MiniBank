using FluentValidation;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Currencies;

namespace MiniBank.API.Validators.Currencies
{
    public class UpdateCurrencyDTOValidator : AbstractValidator<UpdateCurrencyDTO>
    {
        private readonly IRepositoryBase<Currency> _currencyRepository;

        public UpdateCurrencyDTOValidator(IRepositoryBase<Currency> currencyRepository, IRepositoryBase<Transaction> transactionRepository)
        {
            _currencyRepository = currencyRepository;

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Currency code is required.")
                .MustAsync(async (code, cancellationToken) =>
                {
                    var exists = await _currencyRepository.FirstOrDefaultAsync(c => c.Code == code, cancellationToken);
                    return exists == null;
                }).WithMessage("Currency code must be unique.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Currency name is required.");

            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Currency symbol is required.");

        }
    }
}
