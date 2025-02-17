using AdvancedCachingExample.Models;

namespace AdvancedCachingExample.Repositories
{
    public interface IWeatherRepository
    {
        Task<IEnumerable<WeatherForecast>> GetAllWeatherAsync();
        Task<WeatherForecast> AddWeatherAsync(WeatherForecast weather);
    }
}
