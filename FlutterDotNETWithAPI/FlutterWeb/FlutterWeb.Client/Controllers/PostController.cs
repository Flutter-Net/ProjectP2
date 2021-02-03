using System;
using System.Net.Http;
using System.Net.Http.Json;
using FlutterWeb.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlutterWeb.Client.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        HttpClient client;

        public PostController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddPost(string Content,  string UserName)
        {

            var model = new PostViewModel();
            model.UserName = UserName;
            
            model.Content = Content;
            model.CommentOf = 0;

            var postPost = client.PostAsJsonAsync<PostViewModel>("https://localhost:6001/AddPost", model);

            var res = postPost.Result;

            if (res.IsSuccessStatusCode)
            {
                var userModel = new UserViewModel();
                userModel.UserName = UserName;
                return View("Profile", userModel);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpGet("Like/{id}")]
        public IActionResult Like( long id)
        {
            var model = new PostViewModel();
            model.PostId = id;
            
            var postLike = client.PutAsJsonAsync<PostViewModel>("https://localhost:6001/Like", model);
            var res = postLike.Result;
            if(res.IsSuccessStatusCode){

            return View("Feed",model);
            }else
            {
                var error = new ErrorViewModel();
                return View("Error",error);
            }
        }
        [HttpGet("DisLike/{id}")]
        public IActionResult DisLike( long id)
        {
            var model = new PostViewModel();
            model.PostId = id;
            
            var postLike = client.PutAsJsonAsync<PostViewModel>("https://localhost:6001/DisLike", model);
            var res = postLike.Result;
            if(res.IsSuccessStatusCode){

            return View("Feed",model);
            }else
            {
                var error = new ErrorViewModel();
                return View("Error",error);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Post()
        {
            return View("Post");
        }
    }
}
