using FluentValidation;
using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Accounts;

namespace MiniBank.API.Validators.Accounts
{
    public class InsertAccountDtoValidator : AbstractValidator<InsertAccountDTO>
    {
        private readonly IRepositoryBase<Customer> _customerRepository;
        private readonly IRepositoryBase<Account> _accountRepository;
        private readonly IRepositoryBase<AccountType> _accountTypeRepository;
        private readonly IRepositoryBase<Currency> _currencyRepository;

        public InsertAccountDtoValidator(
            IRepositoryBase<Customer> customerRepository,
            IRepositoryBase<Account> accountRepository,
            IRepositoryBase<AccountType> accountTypeRepository,
            IRepositoryBase<Currency> currencyRepository)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _accountTypeRepository = accountTypeRepository;
            _currencyRepository = currencyRepository;

            RuleFor(x => x.customerID)
                .NotEmpty().WithMessage("Customer ID is required")
                .MustAsync(async (id, cancellation) =>
                    await _customerRepository.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted, cancellation) != null)
                .WithMessage("Customer must exist and not be deleted");

            RuleFor(x => x.accountTypeId)
                .NotEmpty().WithMessage("Account Type ID is required")
                .MustAsync(async (id, cancellation) =>
                    await _accountTypeRepository.FirstOrDefaultAsync(a => a.Id == id, cancellation) != null)
                .WithMessage("Account Type must be valid");

            RuleFor(x => x.accountCurrencyId)
                .NotEmpty().WithMessage("Account Currency ID is required")
                .MustAsync(async (id, cancellation) =>
                    await _currencyRepository.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted, cancellation) != null)
                .WithMessage("Currency must exist and not be deleted");

            RuleFor(x => x.accountNumber)
                .NotEmpty().WithMessage("Account Number is required")
                .InclusiveBetween(100000, 99999999).WithMessage("Account Number must be a 10-digit number") // 10 haneli int kontrolü
                .MustAsync(async (accountNumber, cancellation) =>
                    await _accountRepository.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber, cancellation) == null)
                .WithMessage("Account Number must be unique");

            RuleFor(x => new { x.customerID, x.accountTypeId })
                .MustAsync(async (dto, cancellation) =>
                    await _accountRepository.FirstOrDefaultAsync(a => a.CustomerId == dto.customerID && a.AccountTypeId == dto.accountTypeId, cancellation) == null)
                .WithMessage("Customer cannot have another account of the same type");
        }
    }


}
