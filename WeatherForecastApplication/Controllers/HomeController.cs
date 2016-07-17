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
        private WeatherService weatherService;
        List<string> cities;

        public HomeController()
        {
            weatherService = new WeatherService();
            cities = new List<string> { "Kiev", "Lviv", "Kharkiv", "Dnipropetrovsk", "Odessa" };
        }
        // GET: /Home/Index
        public ActionResult Index()
        {
            //List<string> cities = new List<string> { "Kiev", "Lviv", "Kharkiv", "Dnipropetrovsk", "Odessa" };
            ViewBag.List = cities;
            return View(cities);
        }

        // GET: /Home/Forecast
        public ActionResult Forecast(string city, string country = "UA", int days = 1)
        {
            return View(weatherService.getForecast(city, country, days));
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