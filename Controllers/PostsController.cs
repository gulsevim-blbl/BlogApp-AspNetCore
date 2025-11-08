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
    public class PostsController :Controller
    {
        //nesne üretiliyor burada
        private IPostRepository _postRepository; //interface türünde bir nesne tanımladım
        private ICommentRepository _commentRepository;
        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository) 
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        //Taglere göre filtreleme yapalım
        public async Task<IActionResult> Index(string tag)
        {
            var claims = User.Claims;

            var posts = _postRepository.Posts; //veritabanindaki postlari çekiyorum.

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag)); //eğer tag boş değilse postlari tag e göre filtreliyorum.
            }

            return View( new PostViewModel { Posts = await posts.ToListAsync() }); //veritabanindaki postlari listeleyip view e gonderiyorum
        }
        //Detay Sayfası oluşturalım
        public async Task<IActionResult> Details(string url)
        {
            return View(await _postRepository
                            .Posts
                            .Include(x => x.Tags)
                            .Include(x => x.Comments)
                            .ThenInclude(x => x.User) //yorum yapan kullanıcıyı da dahil et
                            .FirstOrDefaultAsync(p => p.Url == url)); //dışarıdan id alıp o id ye sahip postu getiriyoruz
        }
        //Yorum Ekleme İşlemi action metodu
        [HttpPost]
        public JsonResult AddComment(int PostId, string UserName, string Text)
        {
            var entity = new Comment
            {
                Text = Text,
                PublishedOn = DateTime.Now,
                PostId = PostId,
                User = new User
                {
                    UserName = UserName,
                    Image = "avatar.jpg"
                }
            };
            _commentRepository.CreateComment(entity);
            // return Redirect("/posts/details/" + Url);
            // return RedirectToRoute("post_details", new { url = Url }); //ikinci yöntem olarak da bu şekilde yönlendirme sağlayabiliriz.

            return Json(new
            {
                UserName,
                Text,
                entity.PublishedOn,
                entity.User.Image
            });
        }
    }
}