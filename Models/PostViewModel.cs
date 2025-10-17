using BlogApp_AspNetCore.Entity;

namespace BlogApp_AspNetCore.Models
{
    public class PostViewModel
    {
        public List<Post> Posts { get; set; } = new();

        public List<Tag> Tags { get; set; } = new();
    }
}