using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Shared.DTOs.Roles;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
       private readonly IRolePermissionService _rolerPermissionService;

        public RolePermissionController(IRolePermissionService rolerPermissionService)
        {
            _rolerPermissionService = rolerPermissionService;
        }

        [HttpPost("CreateRolePermission")]
        public async Task<IActionResult> CreateRolePermission(InsertRolePermissionDTO rolePermissionDto)
        {
            var result = await _rolerPermissionService.CreateRolePermissionAsync(rolePermissionDto);
            return Ok(result);
        }
    }
}
