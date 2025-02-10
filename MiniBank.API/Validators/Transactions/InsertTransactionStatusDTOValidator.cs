using FluentValidation;
using MiniBank.Shared.DTOs.Transactions;

namespace MiniBank.API.Validators.Transactions
{
    public class InsertTransactionStatusDTOValidator : AbstractValidator<InsertTransactionStatusDTO>
    {
        public InsertTransactionStatusDTOValidator()
        {
            
        }
    }
}
