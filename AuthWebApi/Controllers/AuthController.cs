using Microsoft.AspNetCore.Mvc;
using AuthWebApi.Models;
using BL.Services;
using Microsoft.AspNetCore.Identity.Data;
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
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            try
            {
                // ���������� ���������� ������������ ������
                var token = await userLoginService.Login(userLoginRequest.UserLoginOrEmail, userLoginRequest.Password);
                HttpContext.Response.Cookies.Append("myToken", token); // ��������� ����

                // ���������� ����� � ������ ������
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                // �������� � ���������� ������
                return Unauthorized(new { Message = ex.Message });
            }
        }

    }
}
