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
    public class RoleService : IRoleService
    {
        IRepositoryBase<Role> _roleRepository;
        IUnitOfWork _unitOfWork;
        public RoleService(IRepositoryBase<Role> roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InsertRoleDTO> CreateRoleAsync(InsertRoleDTO roleDto)
        {
            var role = RoleMapping.InsertRolesDtoToEntity(roleDto);
            await _roleRepository.AddASync(role, default);
            await _unitOfWork.SaveChangesAsync();
            return roleDto;
        }
    }
}
