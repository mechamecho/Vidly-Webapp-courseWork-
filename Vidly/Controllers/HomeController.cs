using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //Duration is for time in seconds not ms
        //Location choose client if it is for a specific reason,
        //but server if it is for all users
        //VaryByParam is to have different cached pages depending on params * for all params

        [OutputCache(Duration=50, Location = OutputCacheLocation.Server, VaryByParam = "*")]
        public ActionResult Index()
        {
            return View();
        }

        //To disable caching for an action
        [OutputCache (Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}