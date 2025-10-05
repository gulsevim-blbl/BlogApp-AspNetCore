namespace BlogApp_AspNetCore.Entity
{
    public class Tag
    {
        public int TagId { get; set; }
        public string? Text { get; set; }
        //?entityler arası ilişki kurma kısmı

        public List<Post> Posts { get; set; } = new List<Post>(); //*Her bir tag birden fazla posta sahip olabilir.
    
    }
}