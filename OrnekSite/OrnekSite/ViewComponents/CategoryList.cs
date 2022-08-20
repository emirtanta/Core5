using Microsoft.AspNetCore.Mvc;
using OrnekSite.Data;
using System.Linq;

namespace OrnekSite.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public CategoryList(ApplicationDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            //tüm kategorileri getirdik
            var category = _db.Categories.ToList();

            return View(category);
        }
    }
}
