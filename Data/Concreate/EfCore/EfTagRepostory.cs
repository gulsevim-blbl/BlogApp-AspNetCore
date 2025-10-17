using System.Linq;
using BlogApp_AspNetCore.Data.Abstract;
using BlogApp_AspNetCore.Data.Concreate.EfCore;
using BlogApp_AspNetCore.Entity;

namespace BlogApp_AspNetCore.Data.Concreate
{
    public class EfTagRepostory : ITagRepostory
    {
        private readonly BlogContext _context;

        public EfTagRepostory(BlogContext context)
        {
            _context = context;
        }

        public IQueryable<Tag> Tags => _context.Tags;

        public void CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }
    }
}