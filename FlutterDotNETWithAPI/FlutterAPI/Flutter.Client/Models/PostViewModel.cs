namespace Flutter.Client.Models
{
    public class PostViewModel
    {
        public long UserId { get; set; }
        public string Content { get; set; }
        public long CommentOf { get; set; }
    }
}