using FluentValidation;
using MiniBank.Domain.Entities.Roles;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Roles;

namespace MiniBank.API.Validators.Roles
{
    public class InsertRolePermissionDTOValidator : AbstractValidator<InsertRolePermissionDTO>
    {
        private readonly IRepositoryBase<Role> _roleRepository;
        private readonly IRepositoryBase<Permission> _permissionRepository;
        private readonly IRepositoryBase<RolePermission> _rolePermissionRepository;

        public InsertRolePermissionDTOValidator(
            IRepositoryBase<Role> roleRepository,
            IRepositoryBase<Permission> permissionRepository,
            IRepositoryBase<RolePermission> rolePermissionRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;

            RuleFor(x => x.roleId)
                .MustAsync(async (roleId, cancellationToken) =>
                {
                    var role = await _roleRepository.FirstOrDefaultAsync(r => r.Id == roleId, cancellationToken);
                    return role != null;
                }).WithMessage("RoleId must refer to an existing role.");

            RuleFor(x => x.permissionId)
                .MustAsync(async (permissionId, cancellationToken) =>
                {
                    var permission = await _permissionRepository.FirstOrDefaultAsync(p => p.Id == permissionId, cancellationToken);
                    return permission != null;
                }).WithMessage("PermissionId must refer to an existing permission.");

            RuleFor(x => new { x.roleId, x.permissionId })
                .MustAsync(async (dto, cancellationToken) =>
                {
                    var existingRolePermission = await _rolePermissionRepository.FirstOrDefaultAsync(
                        rp => rp.RoleId == dto.roleId && rp.PermissionId == dto.permissionId,
                        cancellationToken);
                    return existingRolePermission == null;
                }).WithMessage("This Role-Permission combination already exists.");
        }
    }
}
