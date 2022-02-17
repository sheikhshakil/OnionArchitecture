using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Service;
using System;

namespace OA.Api.Controllers
{
    public class SaveUserController : Controller
    {
        [HttpPost("/api/saveUser")]
        public IActionResult Index()
        {
            User user = new User
            {
                Email = Request.Form["email"],
                CreationDate = DateTime.Now,
                FullName = Request.Form["fullName"],
                Address = Request.Form["addr"],
                Phone = Request.Form["phone"]
            };

            bool isSaved = new UserService().SaveUser(user);

            if (isSaved)
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
