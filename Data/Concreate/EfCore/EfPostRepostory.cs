//BU interface'i implemente edecek olan bir concrete class yazacağız. EfPostRepository
using BlogApp_AspNetCore.Data.Abstract;
using BlogApp_AspNetCore.Data.Concreate.EfCore;
using BlogApp_AspNetCore.Entity;

namespace BlogApp_AspNetCore.Data.Concreate
{
    public class EfPostRepostory : IPostRepostory
    {
        private readonly BlogContext _context;
        public EfPostRepostory(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
    
}