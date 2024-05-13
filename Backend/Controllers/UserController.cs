using Backend;
using Backend.DB;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApi.DB;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;


    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    private string GenerateUniqueId()
    {
        return Guid.NewGuid().ToString();
    }

    [HttpGet("users")]
    public List<UserModel> GetAllUsers()
    {
        List<UserModel> userModels = new List<UserModel>();
        _userService.GetAllUser().ForEach(user =>
        {
            userModels.Add(new UserModel(user));
        });
        return userModels;
    }

    [HttpDelete("deluser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        _userService.DeleteUser(userId);
        return Ok("Пользователь успешно удален.");
    }

    [HttpPost("adduser")]
    public IActionResult AddUser([FromBody] UserModel userModel)
    {
        try
        {
            User newUser = new User
            {
                Id = int.Parse(GenerateUniqueId()),
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password,
                Roleid = userModel.Idrole

            };

            Role role = _userService.GetRoleByLogin(userModel.Idrole);
            if (role == null)
            {
                return StatusCode(400, "Роль не найдена для пользователя.");
            }

            newUser.Role = role;
            newUser.Role.Role1 = userModel.Rolename;

            _userService.AddUser(newUser);

            return Ok("Новый пользователь успешно добавлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in AddUser method: {ex.Message}");
            return StatusCode(500, "Произошла ошибка при добавлении пользователя.");
        }
    }
}