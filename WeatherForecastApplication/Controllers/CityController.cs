using System.Web.Mvc;
using WeatherForecastApplication.Infrastructure.Context;
using WeatherForecastApplication.Models;
using System.Collections.Generic;
using WeatherForecastApplication.Services;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WeatherForecastApplication.Controllers
{
    public class CityController : Controller
    {
        private ICityService cityService;
        private WeatherContext weatherContext;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
            weatherContext = new WeatherContext();
        }

        // GET: City/Index
        public async Task<ActionResult> Index()
        {
            return View(await weatherContext.Cities.ToListAsync());
        }

        // GET: City/Default
        public ActionResult Default()
        {
            new WeatherContextInitializer().InitializeDatabase(weatherContext);
            return RedirectToAction("Index");
        }
        // GET: City/Add
        public async Task<ActionResult> Add(string city, string country = "UA")
        {
            List<City> allCities = await cityService.GetAllPossibleCitiesAsync();
            if (CityService.IsCityExists(allCities, city, country))
            {
                List<City> cities = await weatherContext.Cities.ToListAsync();
                if (!CityService.IsCityExists(cities, city, country))
                {
                    weatherContext.Cities.Add(new City { Name = city, Country = country });
                    await weatherContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }
        // GET: City/Delete
        public async Task<ActionResult> Delete(string city, string country = "UA")
        {
            weatherContext.Cities.Remove(await weatherContext.Cities.SingleOrDefaultAsync
                (item => item.Name == city && item.Country == country));
            await weatherContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}