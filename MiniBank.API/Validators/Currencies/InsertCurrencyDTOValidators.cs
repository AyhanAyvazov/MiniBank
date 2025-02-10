using FluentValidation;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Currencies;

namespace MiniBank.API.Validators.Currencies
{
    public class InsertCurrencyDTOValidator : AbstractValidator<InsertCurrencyDTO>
    {
        private readonly IRepositoryBase<Currency> _currencyRepository;

        public InsertCurrencyDTOValidator(IRepositoryBase<Currency> currencyRepository)
        {
            _currencyRepository = currencyRepository;

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Currency code is required.")
                .Length(3).WithMessage("Currency code must be exactly 3 characters.")
                .MustAsync(async (code, cancellationToken) =>
                {
                    var exists = await _currencyRepository.FirstOrDefaultAsync(c => c.Code == code, cancellationToken);
                    return exists == null;
                }).WithMessage("Currency code must be unique.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Currency name is required.")
                .MustAsync(async (name, cancellationToken) =>
                {
                    var exists = await _currencyRepository.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
                    return exists == null;
                }).WithMessage("Currency name must be unique.");

            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Currency symbol is required.")
                .Matches(@"^[^\w\d]+$").WithMessage("Currency symbol must be a valid non-alphanumeric character.");
        }
    }
}
