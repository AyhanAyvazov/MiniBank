using FluentValidation;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class UpdateAccountDTOValidator : AbstractValidator<UpdateAccountDTO>
    {
        private readonly IRepositoryBase<Account> _accountRepository;
        private readonly IRepositoryBase<Balance> _balanceRepository;
        private readonly IRepositoryBase<Transaction> _transactionRepository;

        public UpdateAccountDTOValidator(
            IRepositoryBase<Account> accountRepository,
            IRepositoryBase<Balance> balanceRepository,
            IRepositoryBase<Transaction> transactionRepository)
        {
            _accountRepository = accountRepository;
            _balanceRepository = balanceRepository;
            _transactionRepository = transactionRepository;

            RuleFor(x => x.accountTypeId)
                .MustAsync(BeChangeableWhenBalanceIsZero)
                .WithMessage("Account type can only be changed if the balance is zero.");

            RuleFor(x => x.accountCurrencyId)
                .MustAsync(BeChangeableOnlyWhenEmpty)
                .WithMessage("Account currency can only be changed if the account has no transactions.");

            RuleFor(x => x.isLocked)
                .MustAsync(NotBeChangedWhenTransactionsExist)
                .WithMessage("IsLocked cannot be changed if there are active transactions.");
        }

        private async Task<bool> BeChangeableWhenBalanceIsZero(int accountTypeId, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.FirstOrDefaultAsync(a => a.AccountTypeId == accountTypeId && !a.IsDeleted, cancellationToken);
            if (account == null) return false;

            var balance = await _balanceRepository.FirstOrDefaultAsync(b => b.Id == account.Id && b.Amount > 0, cancellationToken);
            return balance == null;
        }

        private async Task<bool> BeChangeableOnlyWhenEmpty(int accountCurrencyId, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.FirstOrDefaultAsync(a => a.AccountCurrencyId == accountCurrencyId && !a.IsDeleted, cancellationToken);
            if (account == null) return false;

            var transactions = await _transactionRepository.GetByAsync(t => t.SourceAccountId == account.Id || t.DestinationAccountId == account.Id, cancellationToken);
            return !transactions.Any();
        }

        private async Task<bool> NotBeChangedWhenTransactionsExist(bool isLocked, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetByAsync(t => !t.IsDeleted, cancellationToken);
            return !transactions.Any();
        }
    }


}
