using AdvancedCachingExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedCachingExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
