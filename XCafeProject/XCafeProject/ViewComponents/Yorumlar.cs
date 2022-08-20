using Microsoft.AspNetCore.Mvc;
using System.Linq;
using XCafeProject.Data;

namespace XCafeProject.ViewComponents
{
    public class Yorumlar:ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public Yorumlar(ApplicationDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            //yorum yapılır yapılmaz yorumun web sayfasında gözükmesini sağlar
            
            //var yorum = _db.Blogs.ToList();

            //return View(yorum);

            //yorum yapılır yapılmaz yorumun web sayfasında gözükmesini sağlar bitti

            // yönetici tarafından yorumlar onaylandıktan sonra web kısmında yorum gözükür
            

            var yorum = _db.Blogs.Where(i=>i.Onay).ToList();

            return View(yorum);

            // yönetici tarafından yorumlar onaylandıktan sonra web kısmında yorum gözükür bitti
        }
    }
}
