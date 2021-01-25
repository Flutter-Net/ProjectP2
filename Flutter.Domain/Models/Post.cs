using System;
using Flutter.Domain.Abstracts;

namespace Flutter.Domain.Models
{
    public class Post : AEntity
    {
      public DateTime DatePosted { get; set; }

      public string Content { get; set; }

      public long CommentOf { get; set; }

      public long CommentID { get; set; }

      public Post()
      {
        DatePosted = DateTime.Now;
      }

      public Post(long id)
      {
        DatePosted = DateTime.Now;
        CommentOf = id;
        CommentID = System.DateTime.Now.Ticks;
      }
    }
}
