using FluentValidation;
using MiniBank.Shared.DTOs.Currencies;

namespace MiniBank.API.Validators.Currencies
{
    public class GetCurrencyDTOValidators : AbstractValidator<GetCurrencyDTO>
    {
        public GetCurrencyDTOValidators()
        {
            
        }
    }
}
