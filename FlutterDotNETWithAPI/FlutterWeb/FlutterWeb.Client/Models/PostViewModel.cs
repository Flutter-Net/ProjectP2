namespace FlutterWeb.Client.Models
{
    public class PostViewModel
    {
        public string UserName { get; set; }
        public string Content { get; set; }
        public long CommentOfId { get; set; }

        public string OGPost {get;set;}

        public long PostId {get;set;}
    }
}