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
        public void AddUser(AUser user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }
        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
            _ctx.SaveChanges();
        }
        public void AddTag(Tag tag)
        {
            var IsTag = _ctx.Tags.FirstOrDefault(dbtag => dbtag.TagName == tag.TagName);

            if (IsTag != null)
            {
                _ctx.Tags.Add(tag);
                _ctx.SaveChanges();
            }

        }
        public Tag GetTag(string Name)
        {
            return _ctx.Tags.FirstOrDefault(tag => tag.TagName == Name);
        }
        public List<string> GetPostsTags(long PostId)
        {
            var Post = _ctx.Posts.FirstOrDefault(DbPost => DbPost.EntityId == PostId);
            List<string> Tags = new List<string>();
            foreach (var Tag in Post.TagIds)
            {
                Tags.Add(Tag.TagName);
            }
            return Tags;
        }
        public List<long> GetPostIds(long Id)
        {
            var PostIds = _ctx.Posts.Where(post => post.UserId == Id).ToList();
            List<long> Ids = new List<long>();
            foreach (var post in PostIds)
            {
                Ids.Add(post.EntityId);
            }
            return Ids;
        }


        public List<Post> GetPosts(long UserID)
        {
            var posts = _ctx.Posts.Where(p => p.UserId == UserID);
            return posts.OrderByDescending(post => post.DatePosted).ToList();
        }

        public AUser GetUser(string UserName)
        {
            return _ctx.Users.FirstOrDefault(u => u.Name == UserName);
        }
        public List<string> GetUsers()
        {
            return _ctx.Users.Select(user => user.Name).ToList();
        }
        public IEnumerable<AUser> GetUserObj()
        {
            return _ctx.Users.ToList();
        }

        public string UserPassword(string UserName)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Name == UserName);
            return user.Password;
        }

    }
}
