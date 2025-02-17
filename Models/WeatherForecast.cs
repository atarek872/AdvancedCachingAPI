using System.ComponentModel.DataAnnotations;

namespace AdvancedCachingExample.Models
{
    public class WeatherForecast
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Temperature { get; set; }
        public DateTime Date { get; set; }
    }
}
