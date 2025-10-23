using System.IO.Compression;
using BlogApp_AspNetCore.Data.Abstract;
using BlogApp_AspNetCore.Data.Concreate.EfCore;
using BlogApp_AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp_AspNetCore.Controllers
{
    public class PostsController :Controller
    {
        //nesne üretiliyor burada
        private  IPostRepository _postRepository; //interface türünde bir nesne tanımladım
        public PostsController(IPostRepository postRepository) 
        {
            _postRepository = postRepository;
        }


        public IActionResult Index()
        {
            return View(
                new PostViewModel
                {
                    Posts = _postRepository.Posts.ToList(),

                }
            ); //veritabanindaki postlari listeleyip view e gonderiyorum
        }
        //Detay Sayfası oluşturalım
        public  async Task<IActionResult> Details(int? id)
        {
            return View(await _postRepository.Posts.FirstOrDefaultAsync(p => p.PostId == id)); //dışarıdan id alıp o id ye sahip postu getiriyoruz
        }
    }
}