using System;
using System.Collections.Generic;
using Flutter.Domain.Abstracts;

namespace Flutter.Domain.Models
{
    public class AUser : AEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Post> Posts { get; set; }
        public AUser()
        {
            DateCreated = DateTime.Now;
            Posts = new List<Post>();
        }
        public AUser(string inputName, string inputPass)
        {
            Name = inputName;
            Password = inputPass;
            DateCreated = DateTime.Now;
            Posts = new List<Post>();
        }
        public void AddPost(Post ToBeAdded)
        {
            Posts.Add(ToBeAdded);
        }
        public void RemovePost(Post ToBeRemoved)
        {
            Posts.Remove(ToBeRemoved);
        }
    }
}
