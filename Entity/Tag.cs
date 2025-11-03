namespace BlogApp_AspNetCore.Entity
{
    public enum TagColors
    {
        primary,
        danger,
        warning,
        success,
        secondary
    }
    public class Tag
    {
        public int TagId { get; set; }
        public string? Text { get; set; }
        public string? Url { get; set; }

        public TagColors? Color { get; set; }
        //?entityler arası ilişki kurma kısmı

        public List<Post> Posts { get; set; } = new List<Post>(); //*Her bir tag birden fazla posta sahip olabilir.
    
    }
}