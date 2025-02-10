using FluentValidation;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class DeleteBalanceDTOValidator : AbstractValidator<DeleteBalanceDTO>
    {
        private readonly IRepositoryBase<Balance> _balanceRepository;
        private readonly IRepositoryBase<Transaction> _transactionRepository;

        public DeleteBalanceDTOValidator(
            IRepositoryBase<Balance> balanceRepository,
            IRepositoryBase<Transaction> transactionRepository)
        {
            _balanceRepository = balanceRepository;
            _transactionRepository = transactionRepository;

            RuleFor(x => x.Id)
                .MustAsync(async (id, cancellationToken) =>
                {
                    var balance = await _balanceRepository.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
                    return balance != null && balance.Amount == 0;
                }).WithMessage("Balance must be zero before deletion.");

            RuleFor(x => x.Id)
                .MustAsync(async (id, cancellationToken) =>
                {
                    var transactions = await _transactionRepository.GetByAsync(t => t.SourceAccountId == id || t.DestinationAccountId == id, cancellationToken);
                    return !transactions.Any();
                }).WithMessage("There should be no active or scheduled transactions linked to this balance.");
        }
    }
}
