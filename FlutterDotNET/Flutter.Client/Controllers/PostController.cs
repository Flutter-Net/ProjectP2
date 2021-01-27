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

    public class PostController : Controller
    {

      private readonly FlutterRepository _ctx;

        public PostController(FlutterRepository context)
        {
            _ctx = context;
        }

        [HttpGet]
        public IActionResult Post()
        {
            return View("Post");
        }

        [HttpPost("/AddPost")]
        public IActionResult AddPost(string content)
        {
          AUser user = _ctx.GetUser(TempData["currentuser"].ToString());
          TempData.Keep("currentuser");
          Post NewPost = new Post(user.EntityId, content);
          _ctx.AddPost(NewPost);
          var model = new UserViewModel();
          model.UserName = user.Name;
          model.DateCreated = user.DateCreated;
          return View("UserProfile", model);
        }


    }
}
