using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Roles;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Roles;
using MiniBank.Shared.Interfaces.IServices;
using MiniBank.Shared.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Infrastructure.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        IRepositoryBase<RolePermission> _rolePermissionRepository;
        IUnitOfWork _unitOfWork;

        public RolePermissionService(IRepositoryBase<RolePermission> rolePermissionRepository, IUnitOfWork unitOfWork)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InsertRolePermissionDTO> CreateRolePermissionAsync(InsertRolePermissionDTO rolePermissionDto)
        {
            var rolePermission = RolePermissionMapping.InsertPermissionsDtoToEntity(rolePermissionDto);
            await _rolePermissionRepository.AddASync(rolePermission, default);
            await _unitOfWork.SaveChangesAsync();
            return rolePermissionDto;
        }

    }
}
