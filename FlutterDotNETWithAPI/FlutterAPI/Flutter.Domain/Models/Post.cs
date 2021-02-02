using System;
using System.Collections.Generic;
using System.Linq;
using Flutter.Domain.Abstracts;

namespace Flutter.Domain.Models
{
    public class Post : AEntity
    {
        public string UserName { get; set; }
        public DateTime DatePosted { get; set; }
        public ICollection<Tag> TagIds { get; set; }
        public string Content { get; set; }
        public long LikeScore { get; set; }
        public long CommentOfId { get; set; }
        public Post() { }
        public Post(string InputUserName, string inputContent)
        {
            AddUserName(InputUserName);
            AddContent(inputContent);
            AddAsComment(0);
            AddDate();
            InitializeLikes();
            AddTags(new List<Tag>());
        }
        public Post(string InputUserName, string inputContent, long CommentOf)
        {
            AddUserName(InputUserName);
            AddContent(inputContent);
            AddAsComment(CommentOf);
            AddDate();
            InitializeLikes();
            AddTags(new List<Tag>());
        }
        public Post(string InputUserName, string inputContent, long CommentOf, IEnumerable<Tag> Tags)
        {
            AddUserName(InputUserName);
            AddContent(inputContent);
            AddAsComment(CommentOf);
            AddDate();
            InitializeLikes();
            AddTags(Tags);
        }
        public void AddUserName(string InputUserName)
        {
            UserName = InputUserName;
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
