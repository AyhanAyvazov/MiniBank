using FluentValidation;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class GetAccountTypeValidator : AbstractValidator<GetAccountTypeDTO>
    {
        public GetAccountTypeValidator()
        {
            
        }
    }
}
