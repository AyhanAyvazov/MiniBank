using FluentValidation;
using MiniBank.Shared.DTOs.Currencies;

namespace MiniBank.API.Validators.Currencies
{
    public class GetExchangeRateDTOValidators : AbstractValidator<GetExchangeRateDTO>
    {
        public GetExchangeRateDTOValidators()
        {
            
        }
    }
}
