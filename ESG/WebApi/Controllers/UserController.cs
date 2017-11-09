using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"{nameof(UserController)} is working!");
        }
    }
}
