using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Shared.DTOs.Roles;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService _rolerService;

        public RoleController(IRoleService rolerService)
        {
            _rolerService = rolerService;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(InsertRoleDTO roleDto)
        {
            var result = await _rolerService.CreateRoleAsync(roleDto);
            return Ok(result);
        }
    }
}
