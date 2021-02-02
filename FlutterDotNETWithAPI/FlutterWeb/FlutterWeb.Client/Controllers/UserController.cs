using System.Net.Http;
using System.Net.Http.Json;
using FlutterWeb.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlutterWeb.Client.Controllers
{
    [Route("[conroller]")]
    public class UserController : Controller
    {

        HttpClient client;

    public UserController(){
      HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        client = new HttpClient(clientHandler);
    }
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
        public IActionResult AddUser(string UserName, string Password)
        {
            var model = new UserViewModel();
            model.UserName = UserName;
            model.Password = Password;

            var postUser = client.PostAsJsonAsync<UserViewModel>("https://localhost:6001/AddUser",model);

            var res = postUser.Result;

            if(res.IsSuccessStatusCode)
            {

            return View("Login");
            }
            else
            {
                return View("Error");
            }

        }
        [HttpGet("/LoginFailed")]
        public IActionResult LoginFail()
        {
          return View("LoginFailed");
        }
    }
}
