using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flutter.Client.Models;
using Flutter.Storing;
using Flutter.Domain.Models;


namespace Flutter.Client.Controllers
{
    [Route("[controller]")]

    public class UserController : Controller
    {


        private readonly FlutterRepository _ctx;

        public UserController(FlutterRepository context)
        {
            _ctx = context;
        }

        [HttpGet("/SignUp")]
        public IActionResult SignUp()
        {

            var model = new UserViewModel();


            return View("SignUp", model);
        }

        [HttpPost("/AddUser")]
        public IActionResult AddUser(string Username, string Password)
        {
            var model = new UserViewModel();
            var user = new AUser(Username,Password);
            _ctx.AddUser(user);
            model.Users = _ctx.GetUsers();

            return View("Users",model);
        }

    }
}