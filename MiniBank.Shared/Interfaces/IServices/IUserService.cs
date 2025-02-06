using MiniBank.Shared.DTOs.Transactions;
using MiniBank.Shared.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Shared.Interfaces.IServices
{
    public interface IUserService
    {
        Task<InsertUserDTO> CreateUserAsync(InsertUserDTO insertUserDto);
    }
}
