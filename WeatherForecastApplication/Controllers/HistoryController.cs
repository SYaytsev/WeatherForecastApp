using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherForecastApplication.Controllers
{
    public class HistoryController : Controller
    {
        public HistoryController()
        {
                
        }

        // GET: History
        public ActionResult Index()
        {
            return View();
        }
    }
}