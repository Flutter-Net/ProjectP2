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

        public AUser GetUser(string UserName)
        {
          return _ctx.Users.FirstOrDefault(u =>u.Name == UserName);
        }
        public List<string> GetUsers()
        {
            return _ctx.Users.Select(user => user.Name).ToList();
        }
        public IEnumerable<AUser> GetUserObj(){
            return _ctx.Users.ToList();
        }

        public string UserPassword(string UserName)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Name == UserName);
            return user.Password;
        }
    }
}
