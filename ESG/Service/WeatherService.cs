using System;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
            _logger.LogTrace("Starting " + nameof(WeatherService));
        }

        public void GetWeather()
        {
            var w = new Random().Next(1, 10);
            _logger.LogInformation(nameof(WeatherService) + " found {WeatherNumber}", w);
        }
    }
}
