using FlutterWeb.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlutterWeb.Client.Controllers
{
  [Route("[controller]")]
  public class FeedController : Controller
  {
   [HttpGet("/Feed")]
    public IActionResult Feed()
    {
      return View("Feed");
    }
   [HttpGet("/FeedLoggedIn")]
    public IActionResult FeedLoggedIn(string UserName,long UserId)
    {
      var model = new UserViewModel();
      model.UserName = UserName;
      model.UserId = UserId;

      return View("FeedLoggedIn",model);
    }
  }
}
