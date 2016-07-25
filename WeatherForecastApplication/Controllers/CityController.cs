using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WeatherForecastApplication.Infrastructure.Context;
using Newtonsoft.Json;
using WeatherForecastApplication.Models;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using WeatherForecastApplication.Services;

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
        public ActionResult Index()
        {
            return View(weatherContext.Cities.ToList());
        }

        // GET: City/Default
        public ActionResult Default()
        {
            new WeatherContextInitializer().InitializeDatabase(weatherContext);
            return RedirectToAction("Index");
        }
        // GET: City/Add
        public ActionResult Add(string city, string country = "UA")
        {
            List<City> allCities = cityService.GetAllPossibleCities();
            if (CityService.IsCityExists(allCities, city, country))
            {
                List<City> cities = weatherContext.Cities.ToList();
                if (!CityService.IsCityExists(cities, city, country))
                {
                    weatherContext.Cities.Add(new City { Name = city, Country = country });
                    weatherContext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        // GET: City/Delete
        public ActionResult Delete(string city, string country = "UA")
        {
            weatherContext.Cities.Remove(weatherContext.Cities.SingleOrDefault(item => item.Name == city && item.Country == country));
            weatherContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}