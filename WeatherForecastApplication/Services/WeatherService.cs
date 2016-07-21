using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Services
{
    public class WeatherService : IWeatherService
    {
        private string apiKey = System.Configuration.ConfigurationManager.AppSettings["APIKey"];

        public IForecast GetForecast(string city, string country, int days)
        {
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0},{1}&cnt={2}&units=metric&APPID={3}",
    city, country, days, apiKey);
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url);
                return (IForecast)JsonConvert.DeserializeObject<Forecast>(response.Result);
            }
        }
    }
}