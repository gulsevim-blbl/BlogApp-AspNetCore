using System.Data.SqlTypes;
using BlogApp_AspNetCore.Entity;

namespace BlogApp_AspNetCore.Data.Abstract
{
    public interface IUserRepository 
    {
        IQueryable<User> Users { get; } 
        void CreateUser(User user);
    
    }
    
}