using MiniBank.Domain.Entities.Roles;
using MiniBank.Shared.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class RoleMapping
    {
        #region Insert Mapping

        public static InsertRoleDTO RolesToInsertRolesDto(this Role role)
        {
            return new InsertRoleDTO(role.Name);
        }

        public static Role InsertRolesDtoToEntity(this InsertRoleDTO  insertRoleDto)
        {
            return new Role
            {
                Name = insertRoleDto.name
            };
        }

        #endregion
    }
}
