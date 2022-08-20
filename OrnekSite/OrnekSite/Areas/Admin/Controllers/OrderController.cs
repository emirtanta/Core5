using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrnekSite.Data;
using OrnekSite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace OrnekSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public OrderDetailsVM OrderVM { get; set; }

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            /* sistemde olan kullanıcıyı  bulur */

            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            /* sistemde olan kullanıcıyı  bulur bitti */

            IEnumerable<OrderHeader> orderHeaderList;

            //rolü admin ise tüm siparişlerin listesini getirdik
            if (User.IsInRole(Diger.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.ToList();
            }

            else
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value).Include(i => i.ApplicationUser);
            }

            return View(orderHeaderList);
        }

        #region Beklenen Siparişler Bölümü

        public IActionResult Beklenen()
        {
            /* sistemde olan kullanıcıyı  bulur */

            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            /* sistemde olan kullanıcıyı  bulur bitti */

            IEnumerable<OrderHeader> orderHeaderList;

            //rolü admin ise beklenen tüm siparişleri getirdik
            if (User.IsInRole(Diger.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.Where(i=>i.OrderStatus==Diger.Durum_Beklemede).ToList();
            }

            //admin olmayan kullanıcılar
            else
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus==Diger.Durum_Beklemede).Include(i => i.ApplicationUser);
            }

            return View(orderHeaderList);
        }

        #endregion

        #region Onaylanan Siparişler Bölümü

        public IActionResult Onaylanan()
        {
            /* sistemde olan kullanıcıyı  bulur */

            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            /* sistemde olan kullanıcıyı  bulur bitti */

            IEnumerable<OrderHeader> orderHeaderList;

            //rolü admin ise beklenen tüm siparişleri getirdik
            if (User.IsInRole(Diger.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.OrderStatus == Diger.Durum_Onaylandı).ToList();
            }

            //admin olmayan kullanıcılar
            else
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus == Diger.Durum_Onaylandı).Include(i => i.ApplicationUser);
            }

            return View(orderHeaderList);
        }

        #endregion

        #region Kargolanan Siparişler Bölümü

        public IActionResult Kargolanan()
        {
            /* sistemde olan kullanıcıyı  bulur */

            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            /* sistemde olan kullanıcıyı  bulur bitti */

            IEnumerable<OrderHeader> orderHeaderList;

            //rolü admin ise beklenen tüm siparişleri getirdik
            if (User.IsInRole(Diger.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.OrderStatus == Diger.Durum_Kargoda).ToList();
            }

            //admin olmayan kullanıcılar
            else
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus == Diger.Durum_Kargoda).Include(i => i.ApplicationUser);
            }

            return View(orderHeaderList);
        }

        #endregion

        public IActionResult Details(int id)
        {
            OrderVM = new OrderDetailsVM
            {
                //siparişi veren kullanıcı
                OrderHeader = _db.OrderHeaders.FirstOrDefault(i => i.Id == id),

                //siparişi getirir
                //Include(x => x.Product)=>siparişte bulunan ürünler
                OrderDetails = _db.OrderDetails.Where(x => x.OrderId == id).Include(x => x.Product)

            };

            return View(OrderVM);

        }

        #region Siparişler/Details sayfasındaki Onaylandi butonu

        [HttpPost]
        [Authorize(Roles =Diger.Role_Admin)]
        public IActionResult Onaylandi()
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(i => i.Id == OrderVM.OrderHeader.Id);

            //sipariş durumu onaylandı olarak değiştirildi
            orderHeader.OrderStatus = Diger.Durum_Onaylandı;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region  Siparişler/Details sayfasındaki KargoyaVer butonu

        [HttpPost]
        [Authorize(Roles = Diger.Role_Admin)]
        public IActionResult KargoyaVer()
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(i => i.Id == OrderVM.OrderHeader.Id);

            //sipariş durumu onaylandı olarak değiştirildi
            orderHeader.OrderStatus = Diger.Durum_Kargoda;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
