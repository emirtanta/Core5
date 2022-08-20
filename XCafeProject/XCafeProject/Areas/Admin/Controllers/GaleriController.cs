﻿using System;
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
    public class GaleriController : Controller
    {
        private readonly ApplicationDbContext _context;

        //resim eklemek için tanımlandı
        private readonly IWebHostEnvironment _he;

        public GaleriController(ApplicationDbContext context, IWebHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        // GET: Admin/Galeri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Galeris.ToListAsync());
        }

        // GET: Admin/Galeri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galeri = await _context.Galeris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galeri == null)
            {
                return NotFound();
            }

            return View(galeri);
        }

        // GET: Admin/Galeri/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Galeri galeri)
        {
            if (ModelState.IsValid)
            {
                #region Resim Ekleme Bölümü


                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    //Site/menu adındaki yere resmi ekler
                    var uploads = Path.Combine(_he.WebRootPath, @"pato-master\galeri");

                    var ext = Path.GetExtension(files[0].FileName);

                    //resim alanı boş değilse resimleri ekler
                    if (galeri.Image != null)
                    {
                        var imagePath = Path.Combine(_he.WebRootPath, galeri.Image.TrimStart('\\'));

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

                    galeri.Image = @"\pato-master\galeri\" + fileName + ext;


                }
                #endregion



                _context.Add(galeri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(galeri);
        }

        // GET: Admin/Galeri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galeri = await _context.Galeris.FindAsync(id);
            if (galeri == null)
            {
                return NotFound();
            }
            return View(galeri);
        }

        // POST: Admin/Galeri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image")] Galeri galeri)
        {
            if (id != galeri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galeri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GaleriExists(galeri.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(galeri);
        }

        // GET: Admin/Galeri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galeri = await _context.Galeris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galeri == null)
            {
                return NotFound();
            }

            return View(galeri);
        }

        // POST: Admin/Galeri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galeri = await _context.Galeris.FindAsync(id);

            var imagePath = Path.Combine(_he.WebRootPath, galeri.Image.TrimStart('\\'));

            //menü silindiğinde menü resmininde silinmesini sağlar
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _context.Galeris.Remove(galeri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GaleriExists(int id)
        {
            return _context.Galeris.Any(e => e.Id == id);
        }
    }
}
