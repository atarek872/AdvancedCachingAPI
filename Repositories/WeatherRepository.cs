using AdvancedCachingExample.Data;
using AdvancedCachingExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedCachingExample.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly ApplicationDbContext _context;

        public WeatherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllWeatherAsync()
        {
            return await _context.WeatherForecasts.AsNoTracking().ToListAsync();
        }

        public async Task<WeatherForecast> AddWeatherAsync(WeatherForecast weather)
        {
            _context.WeatherForecasts.Add(weather);
            await _context.SaveChangesAsync();
            return weather;
        }
    }
}
