using MiniBank.Domain.Entities.Customers;
using MiniBank.Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.DTOs.Users
{
    public record InsertUserDTO(int customerId, int roleId, string userName, string hashedPassword, string mail);
}
