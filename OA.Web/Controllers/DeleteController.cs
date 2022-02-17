using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace OA.Web.Controllers
{
    [ApiController]
    public class DeleteController : Controller
    {
        [HttpGet("/delete")]
        public IActionResult Index(string email)
        {
            string url = $"https://localhost:44375/api/deleteUser?email={email}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/user");
            }
            else
            {
                return Content("Failed to delete!");
            }
        }
    }
}
