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
        public ICollection<Tag> TagIds { get; set; }
        public string Content { get; set; }
        public long LikeScore { get; set; }
        public long CommentOfId { get; set; }
        public Post() { }
        public Post(long inputUserId, string inputContent)
        {
            AddUserId(inputUserId);
            AddContent(inputContent);
            AddAsComment(0);
            AddDate();
            InitializeLikes();
            AddTags(new List<Tag>());
        }
        public Post(long inputUserId, string inputContent, long CommentOf)
        {
            AddUserId(inputUserId);
            AddContent(inputContent);
            AddAsComment(CommentOf);
            AddDate();
            InitializeLikes();
            AddTags(new List<Tag>());
        }
        public Post(long inputUserId, string inputContent, long CommentOf, IEnumerable<Tag> Tags)
        {
            AddUserId(inputUserId);
            AddContent(inputContent);
            AddAsComment(CommentOf);
            AddDate();
            InitializeLikes();
            AddTags(Tags);
        }
        public void AddUserId(long InputUserId)
        {
            UserId = InputUserId;
        }
        public void AddAsComment(long InputPostId)
        {
            CommentOfId = InputPostId;
        }
        public void AddContent(string InputContent)
        {
            Content = InputContent;
        }
        public void AddDate()
        {
            DatePosted = DateTime.Now;
        }
        public void InitializeLikes()
        {
            LikeScore = 0;
        }
        public void AddTags(IEnumerable<Tag> tags)
        {
            TagIds = tags.ToList();
        }
    }
}
