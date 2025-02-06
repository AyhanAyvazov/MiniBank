using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Shared.DTOs.Roles;
using MiniBank.Shared.Interfaces.IServices;

namespace MiniBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost("CreatePermission")]
        public async Task<IActionResult> CreatePermission(InsertPermissionDTO permissionDto)
        {
            var result = await _permissionService.CreatePermissionAsync(permissionDto);
            return Ok(result);
        }
    }
}
