using System.Web.Mvc;

namespace WeatherForecastApplication.Controllers
{
    public class HistoryController : Controller
    {

        /// <summary>
        /// some comment
        /// </summary>
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