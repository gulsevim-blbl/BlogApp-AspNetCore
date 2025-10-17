using System.Data.SqlTypes;
using BlogApp_AspNetCore.Entity;

namespace BlogApp_AspNetCore.Data.Abstract
{
    public interface ITagRepostory
    {
        IQueryable<Tag> Tags { get; } 

        void CreateTag(Tag tag);
    
    }
    
}