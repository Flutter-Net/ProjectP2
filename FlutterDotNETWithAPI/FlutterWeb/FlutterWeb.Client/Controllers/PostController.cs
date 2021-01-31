using Microsoft.AspNetCore.Mvc;

namespace FlutterWeb.Client.Controllers
{
  [Route("[controller]")]
  public class PostController : Controller
  {
    [HttpPost("/AddPost")]
    public IActionResult AddPost()
    {
      return View("Profile");
    }
    [HttpGet]
    public IActionResult Post()
    {
      return View("Post");
    }
  }
}
