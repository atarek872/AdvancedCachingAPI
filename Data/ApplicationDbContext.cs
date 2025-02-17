using AdvancedCachingExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedCachingExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
