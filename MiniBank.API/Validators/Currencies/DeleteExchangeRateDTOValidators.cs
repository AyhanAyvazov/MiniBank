using FluentValidation;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Currencies;

namespace MiniBank.API.Validators.Currencies
{
    public class DeleteExchangeRateDTOValidator : AbstractValidator<DeleteExchangeRateDTO>
    {
        private readonly IRepositoryBase<Transaction> _transactionRepository;

        public DeleteExchangeRateDTOValidator(IRepositoryBase<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;

            RuleFor(x => x.Id)
                .MustAsync(async (exchangeRateId, cancellationToken) =>
                {
                    var transactions = await _transactionRepository.GetByAsync(
                        t => t.Id == exchangeRateId, cancellationToken);
                    return !transactions.Any();
                })
                .WithMessage("Exchange rate is currently in use in active or scheduled transactions.");
        }
    }
}
