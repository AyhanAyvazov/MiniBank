using FluentValidation;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class InsertBalanceDTOValidator : AbstractValidator<InsertBalanceDTO>
    {
        private readonly IRepositoryBase<Account> _accountRepository;
        private readonly IRepositoryBase<Balance> _balanceRepository;

        public InsertBalanceDTOValidator(
            IRepositoryBase<Account> accountRepository,
            IRepositoryBase<Balance> balanceRepository)
        {
            _accountRepository = accountRepository;
            _balanceRepository = balanceRepository;

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be a positive number.");

            RuleFor(x => x.AccountId)
                .MustAsync(async (accountId, cancellationToken) =>
                {
                    var account = await _accountRepository.FirstOrDefaultAsync(a => a.Id == accountId && !a.IsDeleted, cancellationToken);
                    return account != null;
                }).WithMessage("Account must be active.");

            RuleFor(x => new { x.AccountId, x.CurrencyId })
                .MustAsync(async (dto, cancellationToken) =>
                {
                    var account = await _accountRepository.FirstOrDefaultAsync(a => a.Id == dto.AccountId, cancellationToken);
                    return account != null && account.AccountCurrencyId == dto.CurrencyId;
                }).WithMessage("Currency must match the account currency.");

            RuleFor(x => new { x.AccountId, x.CurrencyId })
                .MustAsync(async (dto, cancellationToken) =>
                {
                    var existingBalance = await _balanceRepository.FirstOrDefaultAsync(b => b.AccountId == dto.AccountId && b.CurrencyId == dto.CurrencyId, cancellationToken);
                    return existingBalance == null;
                }).WithMessage("A balance entry for this currency already exists in the account.");
        }
    }
}

