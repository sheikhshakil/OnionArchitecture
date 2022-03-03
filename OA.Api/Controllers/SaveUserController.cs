using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Service;
using System;
using System.Net.Http;

namespace OA.Api.Controllers
{
    public class SaveUserController : Controller
    {
        [HttpPost("/api/saveUser")]
        public IActionResult Index([FromBody] User user)
        {
            user.CreationDate = DateTime.Now;

            bool isSaved = new UserService().SaveUser(user);

            if (isSaved)
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
