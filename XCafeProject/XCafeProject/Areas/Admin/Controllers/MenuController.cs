using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XCafeProject.Data;
using XCafeProject.Models;

namespace XCafeProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        //resim eklemek için tanımlandı
        private readonly IWebHostEnvironment _he;

        public MenuController(ApplicationDbContext context, IWebHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        // GET: Admin/Menu
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Menus.Include(m => m.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        #region Ekleme Bölümü

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                #region Resim Ekleme Bölümü


                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    //Site/menu adındaki yere resmi ekler
                    var uploads = Path.Combine(_he.WebRootPath, @"pato-master\menu");

                    var ext = Path.GetExtension(files[0].FileName);

                    //resim alanı boş değilse resimleri ekler
                    if (menu.Image != null)
                    {
                        var imagePath = Path.Combine(_he.WebRootPath, menu.Image.TrimStart('\\'));

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

                    menu.Image = @"\pato-master\menu\" + fileName + ext;

                    
                }
                #endregion

                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            

            return View(menu);
        }

        #endregion

        // GET: Admin/Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", menu.CategoryId);
            return View(menu);
        }

        // POST: Admin/Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Menu menu)
        {
            

            if (ModelState.IsValid)
            {
                #region Resim Ekleme Bölümü


                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    //Site/menu adındaki yere resmi ekler
                    var uploads = Path.Combine(_he.WebRootPath, @"pato-master\menu");

                    var ext = Path.GetExtension(files[0].FileName);

                    //resim alanı boş değilse resimleri ekler
                    if (menu.Image != null)
                    {
                        var imagePath = Path.Combine(_he.WebRootPath, menu.Image.TrimStart('\\'));

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

                    menu.Image = @"\pato-master\menu\" + fileName + ext;

                    #endregion


                    _context.Update(menu);
                    await _context.SaveChangesAsync();

                }
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", menu.CategoryId);
            return View(menu);
        }

        // GET: Admin/Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Admin/Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);

            var imagePath = Path.Combine(_he.WebRootPath, menu.Image.TrimStart('\\'));

            //menü silindiğinde menü resmininde silinmesini sağlar
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
