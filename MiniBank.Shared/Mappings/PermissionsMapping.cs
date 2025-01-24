using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Entities.Roles;
using MiniBank.Shared.DTOs.Currencies;
using MiniBank.Shared.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class PermissionsMapping
    {
        #region Insert Mapping

        public static InsertPermissionDTO PermissionsToInsertPermissionsDto(this Permission permission)
        {
            return new InsertPermissionDTO(permission.Name);
        }

        public static Permission InsertPermissionsDtoToEntity(this InsertPermissionDTO insertExchangeRateDto)
        {
            return new Permission
            {
                Name = insertExchangeRateDto.name
            };
        }

        #endregion
    }
}
