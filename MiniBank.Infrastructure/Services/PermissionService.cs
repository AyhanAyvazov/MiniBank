using MiniBank.Domain.Entities.Roles;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Roles;
using MiniBank.Shared.DTOs.Transactions;
using MiniBank.Shared.Interfaces.IServices;
using MiniBank.Shared.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Infrastructure.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepositoryBase<Permission> _permissionRepository;
        IUnitOfWork _unitOfWork;

        public PermissionService(IRepositoryBase<Permission> transactionRepository, IUnitOfWork unitOfWork)
        {
            _permissionRepository = transactionRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<InsertPermissionDTO> CreatePermissionAsync(InsertPermissionDTO permissionDto)
        {
            var permission = PermissionsMapping.InsertPermissionsDtoToEntity(permissionDto);
            await _permissionRepository.AddASync(permission, default);
            await _unitOfWork.SaveChangesAsync();
            return permissionDto;
        }
    }
}
