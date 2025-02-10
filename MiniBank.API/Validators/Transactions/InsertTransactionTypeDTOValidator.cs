using FluentValidation;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Transactions
{
    public class InsertTransactionTypeDTOValidator : AbstractValidator<InsertAccountTypeDTO>
    {
        public InsertTransactionTypeDTOValidator()
        {
            
        }
    }
}
