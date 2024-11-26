using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]

    public class AuthorizeController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetInfo() 
        {
            return Ok("ты авторизован");
        }
    
    
    
    
    }

}
