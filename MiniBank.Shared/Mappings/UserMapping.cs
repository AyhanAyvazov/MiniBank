using MiniBank.Domain.Entities.Transactions;
using MiniBank.Domain.Entities.Users;
using MiniBank.Shared.DTOs.Transactions;
using MiniBank.Shared.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Mappings
{
    public static class UserMapping
    {
        #region Insert Mapping

        public static InsertUserDTO ToInsertUserDto(this User user)
        {
            return new InsertUserDTO(user.CustomerId, user.RoleId, user.UserName, user.HashedPassword, user.Mail);
        }

        public static User UserDtoToEntity(this InsertUserDTO  insertUserDto)
        {
            return new User
            {
                CustomerId = insertUserDto.customerId,
                RoleId = insertUserDto.roleId,
                UserName = insertUserDto.userName,
                HashedPassword = insertUserDto.hashedPassword,
                Mail = insertUserDto.mail
            };
        }

        #endregion
    }
}
