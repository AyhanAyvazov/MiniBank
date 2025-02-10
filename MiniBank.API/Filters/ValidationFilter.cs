using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiniBank.API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var parameters = context.ActionDescriptor.Parameters;
            foreach (var parameter in parameters)
            {
                var paramValue = context.ActionArguments[parameter.Name];

                if (paramValue == null) continue;
                var validatorType = typeof(IValidator<>).MakeGenericType(parameter.ParameterType);
                var validator = _serviceProvider.GetService(validatorType) as IValidator;

                if (validator != null)
                {
                    var validationContext = new ValidationContext<object>(paramValue);
                    var validationResult = await validator.ValidateAsync(validationContext);

                    if (!validationResult.IsValid)
                    {
                        context.Result = new BadRequestObjectResult(
                            new
                            {
                                Errors = validationResult.Errors.Select(e => new
                                {
                                    Field = e.PropertyName,
                                    Message = e.ErrorMessage
                                })
                            }
                            );
                        return;
                    }   
                }
            }
            await next();

        }
    }
}
