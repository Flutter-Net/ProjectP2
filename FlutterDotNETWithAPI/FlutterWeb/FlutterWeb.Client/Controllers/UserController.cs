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

    [HttpGet("/LoggingIn")]
    public IActionResult LoggingIn()
    {
      return View("UserProfile");
      //return View("Signup")
    }

    [HttpPost("/AddUser")]
    public IActionResult AddUser()
    {
      return View("Profile");
    }
  }
}
