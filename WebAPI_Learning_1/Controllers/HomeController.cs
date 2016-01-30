using System.Web.Mvc;

namespace WebAPI_Learning_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
