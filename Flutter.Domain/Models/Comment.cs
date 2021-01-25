using System;
using Flutter.Domain.Abstracts;

namespace Flutter.Domain.Models
{
    public class Comment : AEntity
    {
      public DateTime DatePosted { get; set; }

      public string Content { get; set; }

      public Comment()
      {
        DatePosted = DateTime.Now;
      }
    }
}
