using System.Data.Entity;
using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Infrastructure.Context
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("WeatherForecastDB")
        {
            Database.SetInitializer<WeatherContext>(new WeatherContextInitializer());
        }
        public DbSet<City> Cities { get; set; }
}
}