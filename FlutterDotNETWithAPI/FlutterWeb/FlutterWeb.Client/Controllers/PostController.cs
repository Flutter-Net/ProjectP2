using System;
using System.Net.Http;
using System.Net.Http.Json;
using FlutterWeb.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlutterWeb.Client.Controllers
{
  [Route("[controller]")]
  public class PostController : Controller
  {
    [HttpPost("/AddPost/{UserId}/{Content}/{CommentOf}")]
    public IActionResult AddPost(long UserId, string Content, long CommentOf)
    {
      var model = new PostViewModel();
      model.UserId = UserId;
      model.Content = Content;
      model.CommentOf = CommentOf;

      var client = new HttpClient();
      client.BaseAddress= new Uri("https:localhost:6001/AddPost");

      var postModel = client.PostAsJsonAsync("model",model);
      postModel.Wait();

      var result = postModel.Result;
      if(result.IsSuccessStatusCode)
      {
        return View("Profile");
      }
      ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

        return View("Error");
    }



    [HttpGet]
    public IActionResult Post()
    {
      return View("Post");
    }
  }
}
