using System;

namespace FlutterWeb.Client.Models
{
    public class UserViewModel
    {
        public string UserName {get;set;}

        public string Password{get;set;}

         public long UserId { get; set; }
        public string Content { get; set; }
        public long CommentOf { get; set; }
    }
}