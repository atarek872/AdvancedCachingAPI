using AdvancedCachingExample.Models;
using AdvancedCachingExample.Repositories;
using AdvancedCachingExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedCachingExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly ICacheService _cacheService;
        private static readonly string CacheKey = "weather_data";

        public WeatherController(IWeatherRepository weatherRepository, ICacheService cacheService)
        {
            _weatherRepository = weatherRepository;
            _cacheService = cacheService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetWeather()
        {
            var cachedData = _cacheService.Get<IEnumerable<WeatherForecast>>(CacheKey);
            if (cachedData != null)
            {
                return Ok(new { source = "Cache", data = cachedData });
            }

            var weatherData = await _weatherRepository.GetAllWeatherAsync();
            _cacheService.Set(CacheKey, weatherData, TimeSpan.FromMinutes(10));

            return Ok(new { source = "Database", data = weatherData });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddWeather([FromBody] WeatherForecast weather)
        {
            var newWeather = await _weatherRepository.AddWeatherAsync(weather);

            // Invalidate cache after insertion
            _cacheService.Remove(CacheKey);

            return Ok(newWeather);
        }

        [HttpDelete("clear-cache")]
        public IActionResult ClearCache()
        {
            _cacheService.Remove(CacheKey);
            return Ok("Cache cleared successfully.");
        }
    }
}
