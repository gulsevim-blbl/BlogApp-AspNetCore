using System.IO.Compression;
using System.Threading.Tasks;
using BlogApp_AspNetCore.Data.Abstract;
using BlogApp_AspNetCore.Data.Concreate.EfCore;
using BlogApp_AspNetCore.Entity;
using BlogApp_AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp_AspNetCore.Controllers
{
    public class UsersController :Controller
    {
        public UsersController()
        {
            
        }
        
        public IActionResult Login()
        {
            return View();
        }
    }
}