using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Services
{
    public interface IWeatherService
    {
        IForecast GetForecast(string city, string country, int days);
    }
}