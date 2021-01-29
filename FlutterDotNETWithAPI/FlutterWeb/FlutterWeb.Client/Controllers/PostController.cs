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
        [HttpGet("/Profile")]
        public IActionResult Profile(){

          var model = new UserViewModel();
          var user = TempData["User"].ToString();
          model.UserName = user;
          long id = _ctx.GetUserId(user);

          model.Posts = _ctx.GetPosts(id);

          foreach(Post post in model.Posts){
            post.TagIds = _ctx.GetPostsTags(post.EntityId);
          }
           


            return View("UserProfile",model);
        }
        [HttpPost("/AddPost")]
        public IActionResult AddPost(string content,string Tag)
        {
          AUser user = _ctx.GetUser(TempData["currentuser"].ToString());
          TempData.Keep("currentuser");
          Post NewPost = new Post(user.EntityId, content);

          Tag DbCheck = _ctx.GetTag(Tag);

          if(DbCheck != null ){
            NewPost.TagIds.Add(DbCheck);
          }else{
            Tag NewTag = new Tag(Tag);
            _ctx.AddTag(NewTag);
            NewPost.TagIds.Add(NewTag);
          }

          _ctx.AddPost(NewPost);
          var model = new UserViewModel();
          model.UserName = user.Name;
          TempData["User"]= model.UserName;
          model.DateCreated = user.DateCreated;
          model.Posts = _ctx.GetPosts(user.EntityId);
          return RedirectToAction("Profile",model);
        }


    }
}
