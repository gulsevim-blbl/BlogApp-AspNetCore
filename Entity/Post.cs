namespace BlogApp_AspNetCore.Entity
{
    public class Post
    {
        public int PostId { get; set; } //primary key
        public string? Title { get; set; } 
        public string? Content { get; set; } 

        public DateTime PublishedOn { get; set; } 
        public bool IsActive { get; set; } //post yayında mı değil mi
        //?entityler arası ilişki kurma kısmı
        // Navigation Property (ilişki)
        public int UserId { get; set; }
        public User User { get; set; } = null!; //*Her bir post bir user'a ait olacak.


        public List<Tag> Tags { get; set; } = new List<Tag>(); //*Her bir post birden fazla tag'a sahip olabilir.

        public List<Comment> Comments { get; set; } = new List<Comment>(); //*Her bir post birden fazla comment'a sahip olabilir.
    

    }
}