using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecastApplication.Models.Enums;
using WeatherForecastApplication.Services;

namespace WeatherForecastApplication.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherService weatherService;
        List<string> cities;

        public HomeController(IWeatherService weatherService)
        {
            //weatherService = new WeatherService();
            this.weatherService = weatherService;
            cities = new List<string> { "Kiev", "Lviv", "Kharkiv", "Dnipropetrovsk", "Odessa" };
        }
        // GET: /Home/Index
        public ActionResult Index()
        {
            ViewBag.List = cities;
            return View(cities);
        }

        // GET: /Home/Forecast
        public ActionResult Forecast(string city, string country = "UA", int days = 1)
        {
            return View(weatherService.GetForecast(city, country, days));
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}