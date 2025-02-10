using FluentValidation;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Transactions;

namespace MiniBank.API.Validators.Transactions
{
    public class InsertTransactionDTOValidator : AbstractValidator<InsertTransactionDTO>
    {
        private readonly IRepositoryBase<Account> _accountRepository;
        private readonly IRepositoryBase<Currency> _currencyRepository;

        public InsertTransactionDTOValidator(
            IRepositoryBase<Account> accountRepository,
            IRepositoryBase<Currency> currencyRepository)
        {
            _accountRepository = accountRepository;
            _currencyRepository = currencyRepository;

            RuleFor(x => x.sourceAccountId)
                .MustAsync(async (accountId, cancellationToken) =>
                {
                    var account = await _accountRepository.FirstOrDefaultAsync(a => a.Id == accountId && !a.IsDeleted, cancellationToken);
                    return account != null;
                }).WithMessage("SourceAccountId must refer to an active account.");

            RuleFor(x => x.destionationAccountId)
                .MustAsync(async (accountId, cancellationToken) =>
                {
                    var account = await _accountRepository.FirstOrDefaultAsync(a => a.Id == accountId && !a.IsDeleted, cancellationToken);
                    return account != null;
                }).WithMessage("DestinationAccountId must refer to an active account.");

            RuleFor(x => x.currencyId)
                .MustAsync(async (dto, currencyId, cancellationToken) =>
                {
                    var sourceAccount = await _accountRepository.FirstOrDefaultAsync(a => a.Id == dto.sourceAccountId, cancellationToken);
                    return sourceAccount != null && sourceAccount.AccountCurrencyId == currencyId;
                }).WithMessage("CurrencyId must match the source account's currency.");

            RuleFor(x => x.amount)
                .GreaterThan(0).WithMessage("Amount must be a positive number.")
                .LessThanOrEqualTo(10000).WithMessage("Amount must be within the allowed limits."); // Örnek limit

            RuleFor(x => x.transactionExecuteTime)
                .Must(executeTime => executeTime >= DateTime.UtcNow)
                .WithMessage("TransactionExecuteTime cannot be in the past.");
        }
    }
}
