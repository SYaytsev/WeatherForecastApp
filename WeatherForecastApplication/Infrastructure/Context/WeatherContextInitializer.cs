using System.Data.Entity;
using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Infrastructure.Context
{
    public class WeatherContextInitializer : DropCreateDatabaseIfModelChanges<WeatherContext>
    //DropCreateDatabaseAlways
    //DropCreateDatabaseIfModelChanges
    {
        protected override void Seed(WeatherContext context)
        {
            context.Cities.Add(new City { Name = "Kiev", Country = "UA" });
            context.Cities.Add(new City { Name = "Lviv", Country = "UA" });
            context.Cities.Add(new City { Name = "Kharkiv", Country = "UA" });
            context.Cities.Add(new City { Name = "Dnipropetrovsk", Country = "UA" });
            context.Cities.Add(new City { Name = "Odessa", Country = "UA" });
            context.SaveChanges();
        }
    }
}