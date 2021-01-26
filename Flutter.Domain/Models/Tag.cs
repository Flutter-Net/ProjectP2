  
using System.Collections.Generic;
using Flutter.Domain.Abstracts;

namespace Flutter.Domain.Models
{
    public class Tag : AEntity
    {
        public string TagName { get; set; }
        public List<Post> TaggedPosts { get; set; }
        public Tag() { }
        public Tag(string name)
        {
            TagName = name;
        }
    }
}
