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
  HttpClient client = new HttpClient();

    [HttpPost]
    public IActionResult AddPost(long UserId, string Content){

      var model = new PostViewModel();
      model.UserId = UserId;
      model.Content=Content;
      model.CommentOf=0;

     var postPost =  client.PostAsJsonAsync<PostViewModel>("https://localhost:6001/AddPost",model);   

     var res = postPost.Result;

    if(res.IsSuccessStatusCode)
    {
      return View("Profile");
    }
    else
    {
      return View("Error");
    }
    }
    [HttpGet]
    public IActionResult Post()
    {
      return View("Post");
    }
  }
}
