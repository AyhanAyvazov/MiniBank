using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Roles
{
    public class RolePermissions : EntityBase
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
