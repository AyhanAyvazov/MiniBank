using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Shared.DTOs.Users;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(InsertUserDTO userDto)
        {
            var result = await _userService.CreateUserAsync(userDto);
            return Ok(result);
        }
    }
}
