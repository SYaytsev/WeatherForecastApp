using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAllPossibleCitiesAsync();
    }
}