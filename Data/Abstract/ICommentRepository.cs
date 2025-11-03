using System.Data.SqlTypes;
using BlogApp_AspNetCore.Entity;

namespace BlogApp_AspNetCore.Data.Abstract
{
    public interface ICommentRepository 
    {
        IQueryable<Comment> Comments { get; } 
        void CreateComment(Comment comment);
    
    }
    
}