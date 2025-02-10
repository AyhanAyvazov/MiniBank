using FluentValidation;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class GetBalanceDTOValidator : AbstractValidator<GetBalanceDTO>
    {
        public GetBalanceDTOValidator()
        {
            
        }
    }
}
