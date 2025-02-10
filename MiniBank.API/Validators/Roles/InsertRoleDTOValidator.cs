using FluentValidation;
using MiniBank.Domain.Entities.Roles;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Roles;

namespace MiniBank.API.Validators.Roles
{
    public class InsertRoleDTOValidator : AbstractValidator<InsertRoleDTO>
    {
        private readonly IRepositoryBase<Role> _roleRepository;

        public InsertRoleDTOValidator(IRepositoryBase<Role> roleRepository)
        {
            _roleRepository = roleRepository;

            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Role name cannot be empty.")
                .Length(3, 50).WithMessage("Role name must be between 3 and 50 characters.")
                .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Role name can only contain letters, numbers, and spaces.")
                .MustAsync(async (name, cancellationToken) =>
                {
                    var existingRole = await _roleRepository.FirstOrDefaultAsync(r => r.Name == name, cancellationToken);
                    return existingRole == null;
                }).WithMessage("Role name must be unique.");
        }
    }
}
