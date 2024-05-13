using Backend;
using Microsoft.AspNetCore.Mvc;
using WebApi.DB;



[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUserService _userService;


    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

   [HttpPost("login")]
public IActionResult CheckLogin([FromBody] UserLoginModel loginModel)
{
    var user = _userService.GetUserByLogin(loginModel.Username, loginModel.Password);

        if (user != null)
        {
            if (user.Name != loginModel.Username)
            {
                return BadRequest("Неверное имя пользователя.");
            }
            else if (user.Password != loginModel.Password)
            {
                return BadRequest("Неверный пароль.");
            }
            else
            {
                return Ok("Вход выполнен успешно!");
            }

        }

        else 
        {
            return BadRequest("Вы не ввели данные.");
        }
}
}
