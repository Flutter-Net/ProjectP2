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
       
         
        [HttpGet("/post/posts")]
        public IActionResult GetPosts()
        {
            var posts = _ctx.Posts.ToList();
            return Ok(posts);
        }
        [HttpGet("/post/{id}/comments")]
        public IActionResult GetPostsComments(long id)
        {
            var posts = _ctx.Posts.Where(post => post.CommentOfId == id);
            
            return Ok(posts);
        }

        [HttpGet("/post/{id}")]
        public IActionResult GetPost(long id)
        {
            var post = _ctx.Posts.FirstOrDefault(post => post.EntityId == id);

            return Ok(post);
        }
        [HttpGet("/posts/{user}")]
        public IActionResult GetPost(string user)
        {
            var post = _ctx.Posts.Where(post => post.UserName == user);
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
            Post ToBeAdded = new Post(model.UserName, model.Content, model.CommentOfId);
            _ctx.Posts.Add(ToBeAdded);
            _ctx.SaveChanges();

            return Ok();
        }

        [HttpPut("/Like")]
        public IActionResult Like(PostViewModel model)
        {
            var postToLike = _ctx.Posts.Where(post => post.EntityId == model.PostId).FirstOrDefault<Post>();
            postToLike.LikeScore = postToLike.LikeScore +1;
            _ctx.SaveChanges();

            return Ok();
        }
        [HttpPut("/DisLike")]
        public IActionResult DisLike(PostViewModel model)
        {
            var postToLike = _ctx.Posts.Where(post => post.EntityId == model.PostId).FirstOrDefault<Post>();
            postToLike.LikeScore = postToLike.LikeScore -1;
            _ctx.SaveChanges();

            return Ok();
        }
       
    }
}

