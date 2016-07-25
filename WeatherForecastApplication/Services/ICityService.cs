using System.Collections.Generic;
using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Services
{
    public interface ICityService
    {
        List<City> GetAllPossibleCities();
    }
}