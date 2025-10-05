namespace BlogApp_AspNetCore.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public DateTime PublishedOn { get; set; }
        //?entityler arası ilişki kurma kısmı

        public int PostId { get; set; }
        public Post Post { get; set; } = null!; //*Her bir comment bir post'a ait olacak.
         public int UserId { get; set; }
        public User User { get; set; } = null!; //*Her bir comment bir user'a ait olacak.
    }
}