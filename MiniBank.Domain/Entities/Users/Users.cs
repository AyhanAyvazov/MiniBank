using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Users
{
    public class Users : EntityBase
    {
        public int CustomerId { get; set; }
        public int RoleId { get; set; }

        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string Mail { get; set; }
    }
}
