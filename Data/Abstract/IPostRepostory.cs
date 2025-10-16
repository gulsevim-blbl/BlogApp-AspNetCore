using System.Data.SqlTypes;
using BlogApp_AspNetCore.Entity;

namespace BlogApp_AspNetCore.Data.Abstract
{
    public interface IPostRepostory
    {
        IQueryable<Post> Posts { get; } // peki neden IQueryable kullandık? Çünkü veritabanından verileri çekerken, filtreleme, sıralama gibi işlemleri daha verimli yapabilmek için IQueryable kullanmak daha avantajlıdır. IQueryable, LINQ sorgularını veritabanı seviyesinde çalıştırarak performansı artırır.
        //Ben context üzerinden bütün post'ları aldığım zaman ekstra filtrelemeye devam edebileceğim.

        //Peki neden query türü tanımlıyoruz bu listenin bir versiyonu tabii ki IQueryable olması demek.Ben context üzerinden bütün post'ları aldığım zaman ekstra filtrelemeye devam edebileceğim.Bunu yaptığınızda aslında query tamamlanmış bir query ve üzerine ekstra kriterler ekleyebileceksiniz.Eğer iEnumerable yazmış olsanız bütün postları alıp bu şekilde geri gönderip ekstra filtreleme yapabilirsiniz.Ancak veritabanından tüm postları alıp daha sonra filtreleme yapmak ne kadar mantıklı?

        void CreatePost(Post post);
    
    }
    
}