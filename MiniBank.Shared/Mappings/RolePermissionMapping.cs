using MiniBank.Domain.Entities.Roles;
using MiniBank.Shared.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class RolePermissionMapping
    {
        #region Insert Mapping

        public static InsertRolePermissionDTO RolesToInsertRolesDto(this RolePermission rolePermission)
        {
            return new InsertRolePermissionDTO(rolePermission.RoleId, rolePermission.PermissionId);
        }

        public static RolePermission InsertPermissionsDtoToEntity(this InsertRolePermissionDTO insertRolePermissionDto)
        {
            return new RolePermission
            {
                RoleId = insertRolePermissionDto.roleId,
                PermissionId = insertRolePermissionDto.permissionId
            };
        }

        #endregion
    }
}
