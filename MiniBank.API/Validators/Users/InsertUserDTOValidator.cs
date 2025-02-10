using FluentValidation;
using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Entities.Roles;
using MiniBank.Domain.Entities.Users;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Users;

namespace MiniBank.API.Validators.Users
{
    public class InsertUserDTOValidator : AbstractValidator<InsertUserDTO>
    {
        private readonly IRepositoryBase<Customer> _customerRepository;
        private readonly IRepositoryBase<Role> _roleRepository;
        private readonly IRepositoryBase<User> _userRepository;

        public InsertUserDTOValidator(
            IRepositoryBase<Customer> customerRepository,
            IRepositoryBase<Role> roleRepository,
            IRepositoryBase<User> userRepository)
        {
            _customerRepository = customerRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;

            RuleFor(x => x.customerId)
                .MustAsync(async (customerId, cancellationToken) =>
                {
                    var customer = await _customerRepository.FirstOrDefaultAsync(c => c.Id == customerId && !c.IsDeleted, cancellationToken);
                    return customer != null;
                }).WithMessage("CustomerId must refer to an existing and active customer.");

            RuleFor(x => x.roleId)
                .MustAsync(async (roleId, cancellationToken) =>
                {
                    var role = await _roleRepository.FirstOrDefaultAsync(r => r.Id == roleId, cancellationToken);
                    return role != null;
                }).WithMessage("RoleId must refer to an existing role.");

            RuleFor(x => x.userName)
                .NotEmpty().WithMessage("Username is required.")
                .Length(6, 20).WithMessage("Username must be between 6 and 20 characters.")
                .MustAsync(async (userName, cancellationToken) =>
                {
                    var existingUser = await _userRepository.FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
                    return existingUser == null;
                }).WithMessage("Username must be unique.");

            RuleFor(x => x.hashedPassword)
                .NotEmpty().WithMessage("Password is required.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Password must be at least 8 characters long and contain one uppercase letter, one lowercase letter, one number, and one special character.");

            RuleFor(x => x.mail)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
