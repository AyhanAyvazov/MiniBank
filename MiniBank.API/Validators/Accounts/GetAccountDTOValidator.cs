using FluentValidation;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class GetAccountDTOValidator : AbstractValidator<GetAccountDTO>
    {
        public GetAccountDTOValidator()
        {
        }
    }
}
