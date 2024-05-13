using Backend;
using Backend.DB;
using Microsoft.AspNetCore.Mvc;
using WebApi.DB;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IUserService _userService;


    public RoleController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("roles")]
    public List<RoleModel> GetAllRoles()
    {
        List<RoleModel> roleModels = new List<RoleModel>();
        _userService.GetAllRole().ForEach(role =>
        {
            roleModels.Add(new RoleModel(role));
        });
        return roleModels;
    }

    [HttpDelete("delrole/{roleId}")]
    public IActionResult DeleteRole(int roleId)
    {
        _userService.DeleteRole(roleId);
        return Ok("Роль успешно удалена.");
    }
}