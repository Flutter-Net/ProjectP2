using System.Net.Http;
using System.Net.Http.Json;
using FlutterWeb.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlutterWeb.Client.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        //HttpContext.User is where the user is stored
        
        [Authorize]
        [HttpGet("/profile")]
        public IActionResult Profile()
        {
            var model = new UserViewModel();
            model.UserName = HttpContext.User.Identity.Name;

            return View("Profile",model);
        }
    }
}
