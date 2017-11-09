using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation(nameof(UserController) + " is working!");
            return Ok($"{nameof(UserController)} is working!");
        }

        [HttpGet, Route("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogDebug("User with {RequestedId} requested", id);

            var user = new User(id);
            _logger.LogInformation("{@User} found", user);

            return Json(user);
        }
    }
}
