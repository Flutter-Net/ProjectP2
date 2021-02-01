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
  HttpClient client;
  
    public PostController(){
      HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        client = new HttpClient(clientHandler);
    }
    
    [HttpPost]
    public IActionResult AddPost( string Content, long UserId, string UserName){

      var model = new PostViewModel();
      model.UserId = UserId;
      model.Content=Content;
      model.CommentOf=0;

     var postPost =  client.PostAsJsonAsync<PostViewModel>("https://localhost:6001/AddPost",model);   

     var res = postPost.Result;

    if(res.IsSuccessStatusCode)
    {
      var userModel = new UserViewModel();
      userModel.UserId=UserId;
      userModel.UserName=UserName; 
      return View("Profile",userModel);
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
