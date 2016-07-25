using System.Threading.Tasks;
using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Services
{
    public interface IWeatherService
    {
        Task<IForecast> GetForecastAsync(string city, string country, int days);
    }
}