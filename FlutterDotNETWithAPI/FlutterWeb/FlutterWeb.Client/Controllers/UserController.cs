using FlutterWeb.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlutterWeb.Client.Controllers
{
    [Route("[conroller]")]
    public class UserController : Controller
    {

        [HttpGet("/SignUp")]
        public IActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpGet("/Profile/{name}/{id}")]
        public IActionResult Profile(string name,long id)
        {
            var model = new UserViewModel();
            model.UserName = name;
            model.UserId=id;
            return View("Profile", model);

        }

        [HttpPost("/AddUser")]
        public IActionResult AddUser()
        {
            return View("Profile");
        }
        [HttpGet("/LoginFailed")]
        public IActionResult LoginFail()
        {
          return View("LoginFailed");
        }
    }
}
