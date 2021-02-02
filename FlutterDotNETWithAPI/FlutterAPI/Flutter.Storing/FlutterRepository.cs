using System;
using System.Collections.Generic;
using System.Linq;
using Flutter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Flutter.Domain.Abstracts;


namespace Flutter.Storing
{
    public class FlutterRepository
    {
        private FlutterContext _ctx;
        private int MyProperty { get; set; }

        public FlutterRepository(FlutterContext context)
        {
            _ctx = context;
        }
        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
            _ctx.SaveChanges();
        }
        public void AddTag(Tag tag)
        {
            _ctx.Tags.Add(tag);
            _ctx.SaveChanges();
        }
        public Tag GetTag(string Name)
        {
            return _ctx.Tags.FirstOrDefault(tag => tag.TagName == Name);
        }
        public Post GetPost(long id)
        {
            return _ctx.Posts.FirstOrDefault(post => post.EntityId == id);
        }
        public List<Tag> GetPostsTags(long PostId)
        {
            var post = _ctx.Posts.Include(p => p.TagIds).FirstOrDefault(p => p.EntityId == PostId);
            List<Tag> output = new List<Tag>();
            foreach (Tag tag in post.TagIds)
            {
                output.Add(tag);
            }
            return output;
        }
        public List<string> GetPostsTagNames(long PostId)
        {
            var tags = _ctx.Tags.Where(t => t.EntityId == PostId);
            List<string> names = new List<string>();
            foreach (Tag tag in tags)
            {
                names.Add(tag.TagName);
            }
            return names;
        }
        public List<long> GetPostIds(string UserName)
        {
            var PostIds = _ctx.Posts.Where(post => post.UserName == UserName).ToList();
            List<long> Ids = new List<long>();
            foreach (var post in PostIds)
            {
                Ids.Add(post.EntityId);
            }
            return Ids;
        }


        public List<Post> GetPosts(string UserName)
        {
            var posts = _ctx.Posts.Where(p => p.UserName == UserName);
            return posts.OrderByDescending(post => post.DatePosted).ToList();
        }

        // public AUser GetUser(string UserName)
        // {
        //     return _ctx.Users.FirstOrDefault(u => u.Name == UserName);
        // }
        // public List<AUser> GetAllUsers()
        // {
        //     return _ctx.Users.ToList();
        // }
        // public long GetUserId(string UserName)
        // {
        //     var user = _ctx.Users.FirstOrDefault(u => u.Name == UserName);
        //     return user.EntityId;
        // }
        // public List<string> GetUsers()
        // {
        //     return _ctx.Users.Select(user => user.Name).ToList();
        // }
        // public IEnumerable<AUser> GetUserObj()
        // {
        //     return _ctx.Users.ToList();
        // }

        // public string UserPassword(string UserName)
        // {
        //     var user = _ctx.Users.FirstOrDefault(u => u.Name == UserName);
        //     return user.Password;
        // }

    }
}
