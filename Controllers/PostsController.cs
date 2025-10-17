using BlogApp_AspNetCore.Data.Abstract;
using BlogApp_AspNetCore.Data.Concreate.EfCore;
using BlogApp_AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp_AspNetCore.Controllers
{
    public class PostsController :Controller
    {
        //nesne üretiliyor burada
        private  IPostRepostory _postRepository; //interface türünde bir nesne tanımladım
        private  ITagRepostory _tagRepository;
        public PostsController(IPostRepostory postRepository, ITagRepostory tagRepository) 
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }


        public IActionResult Index()
        {
            return View(
                new PostViewModel
                {
                    Posts = _postRepository.Posts.ToList(),
                    Tags = _tagRepository.Tags.ToList()
                }
            ); //veritabanindaki postlari listeleyip view e gonderiyorum
        }
    }
}