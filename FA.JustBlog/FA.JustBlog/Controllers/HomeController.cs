using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class HomeController : Controller
    {
        [ChildActionOnly]
        public ActionResult AboutCard()
        {
            return PartialView("_PartialAboutCard");
        }
    }
}