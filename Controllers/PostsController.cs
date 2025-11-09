using System.IO.Compression;
using System.Security.Claims;
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
        public JsonResult AddComment(int PostId, string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                PostId = PostId,
                Text = Text,
                PublishedOn = DateTime.Now,
                UserId = int.Parse(userId ?? "")//giriş yapan kullanıcının id sini alıyoruz

            };
            _commentRepository.CreateComment(entity);
            // return Redirect("/posts/details/" + Url);
            // return RedirectToRoute("post_details", new { url = Url }); //ikinci yöntem olarak da bu şekilde yönlendirme sağlayabiliriz.

            return Json(new
            {
                username,
                Text,
                entity.PublishedOn,
                avatar
            });
        }

        public IActionResult Create()
        {
            return View();
        }   

         [HttpPost]
        public IActionResult Create(PostCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _postRepository.CreatePost(
                    new Post {
                        Title = model.Title,
                        Content = model.Content,
                        Url = model.Url,
                        UserId = int.Parse(userId ?? ""),
                        PublishedOn = DateTime.Now,
                        Image = "1.jpg",
                        IsActive = false
                    }
                );
                return RedirectToAction("Index");
            }
            return View(model);
        }       

    }
}