using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Users
{
    public class User : EntityBase
    {
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }

        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string Mail { get; set; }
    }
}
