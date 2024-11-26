using Microsoft.AspNetCore.Mvc;
using AuthWebApi.Models;
using BL.Services;
namespace AuthWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController (UserLoginService userLoginService) : ControllerBase
    {

        [HttpPost("Registration")]
        public IActionResult Registration([FromBody] RegistrationUserLoginRequest request)
        {
            userLoginService.Register(request.UserLogin , request.Email , request.Password);
        return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest  userLoginRequest)
        {
            userLoginService.Login(userLoginRequest.UserLoginOrEmail, userLoginRequest.Password);
            return Ok(userLoginRequest.UserLoginOrEmail);
        }

    }
}
