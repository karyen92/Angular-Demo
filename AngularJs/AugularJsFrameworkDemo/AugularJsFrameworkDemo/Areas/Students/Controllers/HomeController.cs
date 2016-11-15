using System.Web.Mvc;

namespace AugularJsFrameworkDemo.Areas.Students.Controllers
{
    public class HomeController : Controller
    {
        // GET: Students/Home
        public  ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewStudent()
        {
            return View();
        }

    }
}