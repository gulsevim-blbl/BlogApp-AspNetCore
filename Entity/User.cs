namespace BlogApp_AspNetCore.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }

        public string? Image { get; set; }        
        //?entityler arası ilişki kurma kısmı

        public List<Post> Posts { get; set; } = new List<Post>(); //*Her bir user birden fazla posta sahip olabilir.
        public List<Comment> Comments { get; set; } = new List<Comment>(); //*Her bir user birden fazla comment'a sahip olabilir.
    

    }
}