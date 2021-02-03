using FlutterWeb.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlutterWeb.Client.Controllers
{
  [Route("[controller]")]
  public class FeedController : Controller
  {
    [Authorize]
   [HttpGet("/Feed")]
    public IActionResult Feed()
    {
      return View("Feed");
    }
   
  }
}
