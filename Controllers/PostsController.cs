using BlogApp_AspNetCore.Data.Concreate.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp_AspNetCore.Controllers
{
    public class PostsController :Controller
    {
        //nesne üretiliyor burada
        private readonly BlogContext _context; //dependency injection ile contexti aliyoruz 

        public PostsController(BlogContext context) //controllerin constructorina contexti enjekte ettim
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.Posts.ToList()); //veritabanindaki postlari listeleyip view e gonderiyorum
        }
    }
}