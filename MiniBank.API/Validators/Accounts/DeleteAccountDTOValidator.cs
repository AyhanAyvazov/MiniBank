using FluentValidation;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class DeleteAccountDTOValidator : AbstractValidator<DeleteAccountDTO>
    {
        private readonly IRepositoryBase<Account> _accountRepository;
        private readonly IRepositoryBase<Balance> _balanceRepository;
        private readonly IRepositoryBase<Transaction> _transactionRepository;

        public DeleteAccountDTOValidator(
            IRepositoryBase<Account> accountRepository,
            IRepositoryBase<Balance> balanceRepository,
            IRepositoryBase<Transaction> transactionRepository)
        {
            _accountRepository = accountRepository;
            _balanceRepository = balanceRepository;
            _transactionRepository = transactionRepository;

            RuleFor(x => x.id)
                .MustAsync(async (accountId, cancellationToken) =>
                {
                    var balances = await _balanceRepository.GetByAsync(b => b.AccountId == accountId, cancellationToken);
                    return balances.Sum(b => b.Amount) == 0;
                }).WithMessage("Account balance must be zero.");

            RuleFor(x => x.id)
                .MustAsync(async (accountId, cancellationToken) =>
                {
                    var transactions = await _transactionRepository.GetByAsync(t => t.SourceAccountId == accountId || t.DestinationAccountId == accountId, cancellationToken);
                    return !transactions.Any();
                }).WithMessage("There should be no active transactions linked to this account.");
        }

    }
}
