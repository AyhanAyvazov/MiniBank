using FluentValidation;
using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Transactions;

namespace MiniBank.API.Validators.Transactions
{
    public class UpdateTransactionDTOValidator : AbstractValidator<UpdateTransactionDTO>
    {
        public class UpdateTransactionDtoValidator : AbstractValidator<UpdateTransactionDTO>
        {
            private readonly IRepositoryBase<Transaction> _transactionRepository;

            public UpdateTransactionDtoValidator(IRepositoryBase<Transaction> transactionRepository)
            {
                _transactionRepository = transactionRepository;

                RuleFor(x => x.transactionStatusId)
                    .MustAsync(async (transactionDto, newStatusId, cancellationToken) =>
                    {
                        var transaction = await _transactionRepository.FirstOrDefaultAsync(t => t.Id == transactionDto.TransactionId, cancellationToken);
                        if (transaction == null)
                            return false; // İşlem yoksa geçersiz

                        return IsValidStatusChange(transaction.TransactionStatusId, newStatusId);
                    })
                    .WithMessage("Invalid transaction status change.");
            }

            private bool IsValidStatusChange(int currentStatusId, int newStatusId)
            {
                var allowedTransitions = new Dictionary<int, List<int>>
        {
            { 1, new List<int> { 2, 3, 4 } }, // Pending -> Completed, Failed, Cancelled
            { 2, new List<int>() },           // Completed -> (Değiştirilemez)
            { 3, new List<int>() },           // Failed -> (Değiştirilemez)
            { 4, new List<int>() }            // Cancelled -> (Değiştirilemez)
        };

                return allowedTransitions.TryGetValue(currentStatusId, out var validNextStatuses) &&
                       validNextStatuses.Contains(newStatusId);
            }
        }
    } 
}
