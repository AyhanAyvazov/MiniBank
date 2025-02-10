using FluentValidation;
using MiniBank.Domain.Entities.Roles;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Roles;

namespace MiniBank.API.Validators.Roles
{
    public class InsertPermissionDTOValidator : AbstractValidator<InsertPermissionDTO>
    {
        private readonly IRepositoryBase<Permission> _permissionRepository;

        public InsertPermissionDTOValidator(IRepositoryBase<Permission> permissionRepository)
        {
            _permissionRepository = permissionRepository;

            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Permission name cannot be empty.")
                .Length(3, 50).WithMessage("Permission name must be between 3 and 50 characters.")
                .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Permission name can only contain letters, numbers, and spaces.")
                .MustAsync(async (name, cancellationToken) =>
                {
                    var existingPermission = await _permissionRepository.FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
                    return existingPermission == null;
                }).WithMessage("Permission name must be unique.");
        }
    }
}
