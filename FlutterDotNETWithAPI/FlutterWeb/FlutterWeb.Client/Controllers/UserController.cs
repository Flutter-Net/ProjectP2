using System.Net.Http;
using System.Net.Http.Json;
using FlutterWeb.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlutterWeb.Client.Controllers
{
    [Route("[conroller]")]
    public class UserController : Controller
    {
        //HttpContext.User is where the user is stored
        
        [Authorize]
        [HttpGet("/Profile")]
        public IActionResult Profile(string name,long id)
        {
            return View("Profile");
        }
    }
}
