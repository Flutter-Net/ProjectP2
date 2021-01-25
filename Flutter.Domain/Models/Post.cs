using System;
using System.Collections.Generic;
using Flutter.Domain.Abstracts;

namespace Flutter.Domain.Models
{
    public class Post : AEntity
    {
        public long UserId { get; set; }
        public DateTime DatePosted { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
        public long LikeScore { get; set; }
        public Post()
        {
            DatePosted = DateTime.Now;
            Comments = new List<Comment>();
            LikeScore = 0;
        }
        public Post(long inputUserId, string inputContent)
        {
            UserId = inputUserId;
            Content = inputContent;
            DatePosted = DateTime.Now;
            Comments = new List<Comment>();
            LikeScore = 0;
        }
        public void EditContent(string editedContent)
        {
            Content = editedContent;
        }
        public void AddComment(Comment ToBeAdded)
        {
            Comments.Add(ToBeAdded);
        }
        public void RemoveComment(Comment ToBeRemoved)
        {
            Comments.Remove(ToBeRemoved);
        }
    }
}