using FluentValidation;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class DeleteAccountTypeDTOValidator : AbstractValidator<DeleteAccountTypeDTO>
    {
        public DeleteAccountTypeDTOValidator()
        {
            
        }
    }
}
