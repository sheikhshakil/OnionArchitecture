using Microsoft.AspNetCore.Mvc;

namespace OA.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
