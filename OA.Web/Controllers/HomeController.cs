using Microsoft.AspNetCore.Mvc;

namespace OA.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
