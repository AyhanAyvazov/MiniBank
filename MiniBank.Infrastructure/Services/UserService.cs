using MiniBank.Domain.Entities.Accounts;
using MiniBank.Domain.Entities.Users;
using MiniBank.Domain.Interfaces;
using MiniBank.Shared.DTOs.Users;
using MiniBank.Shared.Interfaces.IServices;
using MiniBank.Shared.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Infrastructure.Services
{
    public class UserService : IUserService
    {
        IRepositoryBase<User> _userService;
        IUnitOfWork _unitOfWork;
        public UserService(IRepositoryBase<User> userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<InsertUserDTO> CreateUserAsync(InsertUserDTO insertUserDto)
        {
            var transactionType = UserMapping.UserDtoToEntity(insertUserDto);
            await _userService.AddASync(transactionType, default);
            await _unitOfWork.SaveChangesAsync();
            return insertUserDto;
        }
    }
}
