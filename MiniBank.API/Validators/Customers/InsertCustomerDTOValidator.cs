using FluentValidation;
using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Customers;

namespace MiniBank.API.Validators.Customers
{
    public class InsertCustomerDTOValidator : AbstractValidator<InsertCustomerDto>
    {
        private readonly IRepositoryBase<Customer> _customerRepository;

        public InsertCustomerDTOValidator(IRepositoryBase<Customer> customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(x => x.firstName)
                .NotEmpty().WithMessage("First name is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("First name must contain only letters.")
                .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

            RuleFor(x => x.lastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Matches("^[a-zA-Z]+$").WithMessage("Last name must contain only letters.")
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

            RuleFor(x => x.birthDate)
                .Must(date => date <= DateTime.UtcNow.AddYears(-18))
                .WithMessage("Customer must be at least 18 years old.");

            RuleFor(x => x.personalNumber)
                .Matches("^[0-9]{11}$").WithMessage("Personal number must be exactly 11 digits.")
                .MustAsync(async (personalNumber, cancellationToken) =>
                {
                    var existingCustomer = await _customerRepository.FirstOrDefaultAsync(
                        c => c.PersonalNumber == personalNumber, cancellationToken);
                    return existingCustomer == null;
                }).WithMessage("Personal number must be unique.");

            RuleFor(x => x.mobileNumber)
                .Matches(@"^\+995\d{9}$")
                .WithMessage("Mobile number must be in Georgian format (+995xxxxxxxxx).");
        }
    }
}
