using System.Linq;
using System.Web.Mvc;
using WeatherForecastApplication.Infrastructure.Context;
using WeatherForecastApplication.Services;

namespace WeatherForecastApplication.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherService weatherService;
        private WeatherContext weatherContext;
        //List<string> cities;

        public HomeController(IWeatherService weatherService)
        {
            //weatherService = new WeatherService();
            this.weatherService = weatherService;
            this.weatherContext = new WeatherContext();
            //cities = new List<string> { "Kiev", "Lviv", "Kharkiv", "Dnipropetrovsk", "Odessa" };
        }
        // GET: /Home/Index
        public ActionResult Index()
        {
            /*
            ViewBag.List = cities;
            return View(cities);
            */
            return View(weatherContext.Cities.ToList());
        }

        // GET: /Home/Forecast
        public ActionResult Forecast(string city, string country = "UA", int days = 1)
        {
            return View(weatherService.GetForecast(city, country, days));
        }

        public ActionResult History()
        {
            return View();
        }

        public ActionResult About()
        {
            return View(weatherContext.Cities.ToList());
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}