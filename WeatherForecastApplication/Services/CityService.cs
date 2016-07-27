using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Services
{
    public class CityService : ICityService
    {
        public async Task<List<City>> GetAllPossibleCitiesAsync()
        {
            List<City> allCities = new List<City>();

            string path = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "App_Data\\city.list.json");

            try
            {
                using (var reader = new StreamReader(path))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        allCities.Add(JsonConvert.DeserializeObject<City>(line));
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            /*
            if (File.Exists(path))
            {
                foreach (string line in File.ReadLines(path))
                {
                    allCities.Add(JsonConvert.DeserializeObject<City>(line));
                }
            }
            */

            return await Task.Factory.StartNew(() => allCities);
        }
        public static bool IsCityExists(List<City> cities, string city, string country)
        {
            return cities.Exists(item => item.Name == city && item.Country == country);
        }
    }
}