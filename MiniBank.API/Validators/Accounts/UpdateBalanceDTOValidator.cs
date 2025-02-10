using FluentValidation;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class UpdateBalanceDTOValidator : AbstractValidator<UpdateBalanceDTO>
    {
        private readonly IRepositoryBase<Balance> _balanceRepository;
        private readonly IRepositoryBase<Transaction> _transactionRepository;

        public UpdateBalanceDTOValidator(
            IRepositoryBase<Balance> balanceRepository,
            IRepositoryBase<Transaction> transactionRepository)
        {
            _balanceRepository = balanceRepository;
            _transactionRepository = transactionRepository;

            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Amount cannot be negative.");

            RuleFor(x => x)
                .MustAsync(async (dto, cancellationToken) =>
                {
                    var balance = await _balanceRepository.FirstOrDefaultAsync(b => b.AccountId == dto.AccountId && b.CurrencyId == dto.CurrencyId, cancellationToken);
                    if (balance == null) return false;

                    var overdraftLimit = 1000; // Örnek limit
                    return balance.Amount + dto.Amount >= -overdraftLimit;
                }).WithMessage("Amount exceeds the allowed overdraft limit.");

            RuleFor(x => x)
                .MustAsync(async (dto, cancellationToken) =>
                {
                    var transactions = await _transactionRepository.GetByAsync(t => t.SourceAccountId == dto.AccountId || t.DestinationAccountId == dto.AccountId, cancellationToken);
                    return transactions.All(t => t.Amount + dto.Amount >= 0);
                }).WithMessage("Balance update must be consistent with transaction history.");
        }
    }
}
