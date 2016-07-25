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
            return View(await weatherContext.Cities.ToListAsync());
        }

        // GET: /Home/Forecast
        public async Task<ActionResult> Forecast(string city, string country = "UA", int days = 1)
        {
            return View(await weatherService.GetForecastAsync(city, country, days));
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