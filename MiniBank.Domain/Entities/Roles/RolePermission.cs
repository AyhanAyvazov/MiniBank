using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Roles
{
    public class RolePermission : EntityBase
    {
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public Permission? Permission { get; set; }

    }
}
