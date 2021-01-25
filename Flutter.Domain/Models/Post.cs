using System;
using System.Collections.Generic;
using System.Linq;
using Flutter.Domain.Abstracts;

namespace Flutter.Domain.Models
{
    public class Post : AEntity
    {
        public long UserId { get; set; }
        public DateTime DatePosted { get; set; }
        public List<long> TagIds { get; set; }
        public string Content { get; set; }
        public long LikeScore { get; set; }
        public long CommentOfId { get; set; }
        public Post()
        {
            CommentOfId = 0;
            DatePosted = DateTime.Now;
            LikeScore = 0;
        }
        public Post(long inputUserId, string inputContent)
        {
            UserId = inputUserId;
            CommentOfId = 0;
            Content = inputContent;
            DatePosted = DateTime.Now;
            LikeScore = 0;
        }
        public Post(long inputUserId, string inputContent, long CommentOf)
        {
            UserId = inputUserId;
            Content = inputContent;
            CommentOfId = CommentOf;
            DatePosted = DateTime.Now;
            LikeScore = 0;
        }
        public Post(long inputUserId, string inputContent, long CommentOf,IEnumerable<long> Tags)
        {
            UserId = inputUserId;
            Content = inputContent;
            CommentOfId = CommentOf;
            TagIds = Tags.ToList();
            DatePosted = DateTime.Now;
            LikeScore = 0;
        }
    }
}
