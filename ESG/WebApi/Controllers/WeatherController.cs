using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;

namespace WebApi.Controllers
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _weatherService.GetWeather();
            _logger.LogInformation(nameof(WeatherController) + " is working!");
            return Ok($"{nameof(WeatherController)} is working!");
        }
    }
}
