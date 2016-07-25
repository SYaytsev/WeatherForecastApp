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