﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Services
{
    public class CityService : ICityService
    {
        public List<City> GetAllPossibleCities()
        {
            List<City> allCities = new List<City>();

            string path = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "App_Data\\city.list.json");
            string json = System.IO.File.ReadAllText(path);

            if (System.IO.File.Exists(path))
            {
                foreach (string line in System.IO.File.ReadLines(path))
                {
                    allCities.Add(JsonConvert.DeserializeObject<City>(line));
                }
            }
            return allCities;
        }
        public static bool IsCityExists(List<City> cities, string city, string country)
        {
            return cities.Exists(item => item.Name == city && item.Country == country);
        }
    }
}