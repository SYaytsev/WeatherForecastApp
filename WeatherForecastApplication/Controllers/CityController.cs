using System.Web.Mvc;
using WeatherForecastApplication.Infrastructure.Context;
using WeatherForecastApplication.Models;
using System.Collections.Generic;
using WeatherForecastApplication.Services;
using System.Data.Entity;
using System.Threading.Tasks;
using System;

namespace WeatherForecastApplication.Controllers
{
    public class CityController : Controller
    {
        private ICityService cityService;
        private WeatherContext weatherContext;
        string errorMessage = "";
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
            weatherContext = new WeatherContext();
        }

        // GET: City/Index
        public async Task<ActionResult> Index(string message = "")
        {
            ViewData["Message"] = message;
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
            try
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
                    else
                    {
                        errorMessage = "City is already exists in the list, you can choose it, or Enter other name";
                    }
                }
                else
                {
                    errorMessage = "We can not provide forecats for such city, Enter other name!";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return RedirectToAction("Index", new { message = errorMessage });
        }
        // GET: City/Delete
        public async Task<ActionResult> Delete(string city, string country = "UA")
        {
            try
            {
                weatherContext.Cities.Remove(await weatherContext.Cities.SingleOrDefaultAsync
                    (item => item.Name == city && item.Country == country));
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            await weatherContext.SaveChangesAsync();
            return RedirectToAction("Index", new { message = errorMessage });
        }
    }
}