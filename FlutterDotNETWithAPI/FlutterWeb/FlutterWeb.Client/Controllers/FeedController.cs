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
  }
}
