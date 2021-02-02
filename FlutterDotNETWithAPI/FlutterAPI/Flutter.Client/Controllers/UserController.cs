using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Flutter.Domain.Models;
using Flutter.Storing;
using Microsoft.EntityFrameworkCore;
using Flutter.Client.Models;


namespace Flutter.Client.Controllers
{
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly FlutterContext _ctx;

        public UserController(FlutterContext context)
        {
            _ctx = context;
        }


        [HttpGet("/users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = _ctx.Users.ToList();

            return await Task.FromResult(Ok(users));

        }
        [HttpGet("/user/{name}")]
        public IActionResult GetUser(string name)
        {
            var user = _ctx.Users.Include(u => u.Posts).FirstOrDefault(user => user.Name == name);

            return Ok(user);
        }
        [HttpGet("/user/{name}/posts")]
        public IActionResult GetUserPosts(string name)
        {
            var user = _ctx.Users.FirstOrDefault(user => user.Name == name);
            var posts = _ctx.Posts.Where(post => post.UserId == user.EntityId);
            return Ok(posts);
        }
         
        [HttpGet("/post/posts")]
        public IActionResult GetPosts()
        {
            var posts = _ctx.Posts.ToList();
            return Ok(posts);
        }

        [HttpGet("/post/{id}")]
        public IActionResult GetPost(long id)
        {
            var post = _ctx.Posts.FirstOrDefault(post => post.EntityId == id);

            return Ok(post);
        }

        [HttpGet("/post/Tags/{id}")]
        public IActionResult GetPostTags(long id)
        {
            var post = _ctx.Posts.FirstOrDefault(p => p.EntityId == id);
            var output = post.TagIds;
            foreach (var tag in post.TagIds)
            {
                output.Add(tag);
            }
            return Ok(output);
        }

        [HttpGet("/Tags")]
        public IActionResult GetTags()
        {
            var tags = _ctx.Tags.ToList();

            return Ok(tags);
        }

        [HttpGet("/Tag/{name}")]
        public IActionResult GetTag(string name)
        {
            var tag = _ctx.Tags.FirstOrDefault(tag => tag.TagName == name);

            return Ok(tag);
        }

        [HttpPost("/AddPost")]
        public IActionResult AddPost(PostViewModel model)
        {
            Post ToBeAdded = new Post(model.UserId, model.Content, model.CommentOf);
            _ctx.Posts.Add(ToBeAdded);
            _ctx.SaveChanges();

            return Ok();
        }
        [HttpPost("/AddUser")]
        public IActionResult AddPost(UserViewModel model)
        {
            AUser ToBeAdded = new AUser(model.UserName,model.Password);
            _ctx.Users.Add(ToBeAdded);
            _ctx.SaveChanges();

            return Ok();
        }
    }
}

