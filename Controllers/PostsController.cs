using BlogApp_AspNetCore.Data.Abstract;
using BlogApp_AspNetCore.Data.Concreate.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp_AspNetCore.Controllers
{
    public class PostsController :Controller
    {
        //nesne üretiliyor burada
        private  IPostRepostory _repository; //interface türünde bir nesne tanımladım

        public PostsController(IPostRepostory repository) 
        {
            _repository = repository;
        }


        public IActionResult Index()
        {
            return View(_repository.Posts.ToList()); //veritabanindaki postlari listeleyip view e gonderiyorum
        }
    }
}