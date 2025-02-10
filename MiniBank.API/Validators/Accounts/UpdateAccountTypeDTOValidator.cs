using FluentValidation;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class UpdateAccountTypeDTOValidator : AbstractValidator<UpdateAccountDTO>
    {
        public UpdateAccountTypeDTOValidator()
        {
            
        }
    }
}
