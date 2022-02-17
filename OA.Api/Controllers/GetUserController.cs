using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OA.Data;
using OA.Service;
using System.Collections.Generic;
using System.Linq;

namespace OA.Api.Controllers
{
    [ApiController]
    public class GetUserController : Controller
    {
        private readonly IUserService userService;

        public GetUserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("/api/getUser")]
        public IActionResult Index()
        {
            List<User> userList = new List<User>();

            string email = Request.Query["email"].ToString();

            if (email.Length < 5)
            {
                //get all user
                userList.AddRange(userService.GetAllUser().ToList());
            }
            else
            {
                //get single user
                User user = userService.GetUser(email);
                userList.Add(user);
            }

            return Content(JsonConvert.SerializeObject(userList, Formatting.Indented));
        }
    }
}
