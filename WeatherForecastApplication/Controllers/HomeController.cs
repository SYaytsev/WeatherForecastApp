using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForecastApplication.Infrastructure.Context;
using WeatherForecastApplication.Services;

namespace WeatherForecastApplication.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherService weatherService;
        private WeatherContext weatherContext;

        public HomeController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
            weatherContext = new WeatherContext();
        }
        // GET: /Home/Index
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await weatherContext.Cities.ToListAsync());
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return View("Error");
            }
        }

        // GET: /Home/Forecast
        public async Task<ActionResult> Forecast(string city, string country = "UA", int days = 1)
        {
            try
            {
                return View(await weatherService.GetForecastAsync(city, country, days));
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return View("Error");
            }
        }

        public ActionResult History()
        {
            return View();
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