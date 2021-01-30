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

        private string apiUrl = "http://localhost:57661";

        private HttpClient _http = new HttpClient();


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
        [HttpGet("/Users")]
        public IActionResult Users(){
            var model = new UserViewModel();
            model.Users =_ctx.GetUsers();

            return View("Users",model);
        }
        [HttpGet("/Login")]
        public IActionResult Login(){
            var model = new UserViewModel();
            

            return View("Login",model);
        }
        
        [HttpGet("/UserProfile")]
        public async IActionResult UserProfile()
        {
          var response = await _http.GetAsync(apiUrl);

          if (response.IsSuccessCode)
          {
            var content = Json.Convert<UserViewModel>(await response.Content.ReadStringAsync);
          }
          
          var model = new UserViewModel();
          var user = TempData["currentuser"].ToString();
          TempData.Keep("currentuser");
          model.UserName = user;
          long id = _ctx.GetUserId(user);

          model.Posts = _ctx.GetPosts(id);
                     
          return View("UserProfile",content);
        }

        [HttpPost("/LoggingIn")]
        public IActionResult LoggingIn(string Username, string Password)
        {
            var model = new UserViewModel();
            model.UserName = Username;
            string PasswordDB = _ctx.UserPassword(Username);
            if(PasswordDB == Password){
                AUser user = _ctx.GetUser(Username);
                model.Posts = _ctx.GetPosts(user.EntityId);
                TempData["currentuser"] = Username;
                model.DateCreated = _ctx.GetUser(Username).DateCreated;
                return RedirectToAction("UserProfile",model);
            }
            else{
                return View("SignUp",model);
            }

        }
    }
}
