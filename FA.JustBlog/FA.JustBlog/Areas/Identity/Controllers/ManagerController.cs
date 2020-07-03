using System.Web.Mvc;

namespace FA.JustBlog.Areas.Identity.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Identity/Manager
        public ActionResult Index()
        {
            return View();
        }
    }
}