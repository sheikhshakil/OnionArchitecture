using Microsoft.AspNetCore.Mvc;
using OA.Service;

namespace OA.Api.Controllers
{
    [ApiController]
    public class DeleteUserController : Controller
    {
        [HttpGet("/api/deleteUser")]
        public IActionResult Index(string email)
        {
            if (email.Length < 5)
                return StatusCode(400);
            else
            {
                bool isDeleted = new UserService().DeleteUser(email);
                if (isDeleted)
                    return Ok();
                else
                    return StatusCode(500);
            }
        }
    }
}
