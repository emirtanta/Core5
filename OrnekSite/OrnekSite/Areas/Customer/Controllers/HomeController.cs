using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekSite.Data;
using OrnekSite.Models;
using System.Linq;
using System.Security.Claims;

namespace OrnekSite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //sepete ürün ürün sayısını getirir
            if (claim!=null)
            {
                var count = _db.ShoppingCarts.Where(i => i.ApplicationUserId == claim.Value).ToList().Count();

                //session kısmında ürün sayısı tutulur
                HttpContext.Session.SetInt32(Diger.ssShoppingCart, count);
            }

            var products = _db.Products.Where(x=>x.IsHome==true).ToList();

            return View(products);
        }

        #region Kategori Detay Bölümü Component ile yapıldı

        public IActionResult CategoryDetails(int? id)
        {
            //kategoriye ait ürünleri getirir
            var product = _db.Products.Where(i => i.CategoryId == id).ToList();

            ViewBag.KategoriId = id;

            return View(product);
        }

        #endregion

        #region Ürün Arama Sayfası Bölümü

        public IActionResult Search(string q)
        {
            //q değeri boş değilse
            if (!string.IsNullOrEmpty(q))
            {
                var ara = _db.Products.Where(i => i.Title.Contains(q) || i.Description.Contains(q));

                return View(ara);
            }

            return View();
        }

        #endregion

        #region Ürün Detay Bölümü

        public IActionResult Details(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id==id);


            /**/
            ShoppingCart cart = new ShoppingCart()
            {
                Product = product,
                ProductId = product.Id
            };

            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart scart)
        {
            scart.Id = 0;

            if (ModelState.IsValid)
            {
                //giriş yapan kullanıcıyı buluyoruz
                var claimsIdentity = (ClaimsIdentity)User.Identity;

                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                scart.ApplicationUserId = claim.Value;

                /* hangi kullanıcının hangi ürünü sepete eklediğini belirleme alanı */


                ShoppingCart cart = _db.ShoppingCarts.FirstOrDefault(u => u.ApplicationUserId == scart.ApplicationUserId && u.ProductId == scart.ProductId);

                if (cart==null)
                {
                    //ürünü sepete ekliyoruz
                    _db.ShoppingCarts.Add(scart);
                }

                else
                {
                    //sepette ürün varsa ürünün adetini arttırarak ürünü ekler
                    cart.Count += scart.Count;
                }

                _db.SaveChanges();

                /* session işlemleri */

                //sistemdeki sipariş veren tüm kullanıcıların sayısını getiri
                var count = _db.ShoppingCarts.Where(i => i.ApplicationUserId == scart.ApplicationUserId).ToList().Count();

                HttpContext.Session.SetInt32(Diger.ssShoppingCart, count);

                /* session işlemleri bitti */

                return RedirectToAction(nameof(Index));

                /* hangi kullanıcının hangi ürünü sepete eklediğini belirleme alanı bitti */
            }

            else
            {
                var product = _db.Products.FirstOrDefault(x => x.Id == scart.Id);


                /* sepete farklı ürün varsa ekler */
                ShoppingCart cart = new ShoppingCart()
                {
                    Product = product,
                    ProductId = product.Id
                };
            }

            

            return View(scart);
        }

        #endregion
    }
}
