using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XCafeProject.Data;
using XCafeProject.Models;

namespace XCafeProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        //resim eklemek için tanımlandı
        private readonly IWebHostEnvironment _he;
        private readonly IToastNotification _toast; //toast'ı kullanabilmek için tanımladık

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IToastNotification toast, IWebHostEnvironment he)
        {
            _logger = logger;
            _db = db;
            _toast = toast;
            _he = he;
        }

        public IActionResult Index()
        {
            var menu = _db.Menus.Where(i=>i.Ozel).ToList();

            return View(menu);
        }

        public IActionResult CategoryDetails(int id)
        {
            //Kategoriye ait menüleri getirir
            var menu = _db.Menus.Where(i => i.CategoryId == id).ToList();

            ViewBag.KategoriId = id;

            return View(menu);
        }

        public IActionResult Deneme()
        {
            return View();
        }

        public IActionResult Menu()
        {
            var menu = _db.Menus.ToList();

            return View(menu);
        }

        #region Rezervasyon Bölgesi

        

        [HttpGet]
        public IActionResult Rezervasyon()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezervasyon([Bind("Id,Name,Email,TelefonNo,Sayi,Saat,Tarih")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                _db.Add(rezervasyon);
                await _db.SaveChangesAsync();

                //toast mesajının rezervasyon eklendiğinde gözükmesi için tanımlandı
                _toast.AddSuccessToastMessage("Teşekkür ederiz rezervasyon işleminiz başarıyla gerçekleşti");

                return RedirectToAction(nameof(Index));
            }
            return View(rezervasyon);
        }

        #endregion

        public IActionResult Galeri()
        {
            var galeri = _db.Galeris.ToList();

            return View(galeri);
        }

        public IActionResult About()
        {
            var about = _db.Abouts.ToList();

            return View(about);
        }

        public IActionResult Blog()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Blog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Tarih = DateTime.Now;

                #region Resim Ekleme Bölümü


                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    //Site/menu adındaki yere resmi ekler
                    var uploads = Path.Combine(_he.WebRootPath, @"pato-master\blog");

                    var ext = Path.GetExtension(files[0].FileName);

                    //resim alanı boş değilse resimleri ekler
                    if (blog.Image != null)
                    {
                        var imagePath = Path.Combine(_he.WebRootPath, blog.Image.TrimStart('\\'));

                        //menü silindiğinde menü resmininde silinmesini sağlar
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }

                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }

                    blog.Image = @"\pato-master\blog\" + fileName + ext;


                }
                #endregion

                _db.Add(blog);
                await _db.SaveChangesAsync();

                _toast.AddSuccessToastMessage("Yorumunuz iletildi.Yorumunuz Onaylandığında Yorumunuzu Görebilirsiniz");

                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        public IActionResult Contact()
        {
            return View();
        }

        // POST: Admin/Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {

                contact.Tarih = DateTime.Now;
                _db.Add(contact);

                await _db.SaveChangesAsync();

                _toast.AddSuccessToastMessage("Teşekkür ederiz mesajınız başarıyla iletildi");

                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
