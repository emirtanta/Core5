using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrnekSite.Data;
using OrnekSite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Diger.Role_Admin)]
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.ApplicationUsers.ToList();

            var role = _context.Roles.ToList();

            var userRol = _context.UserRoles.ToList();

            foreach (var item in users)
            {
                var roleId = userRol.FirstOrDefault(i => i.UserId == item.Id).RoleId;

                //rol ismine göre kullanıcıları getirir
                item.Role = role.FirstOrDefault(u => u.Id == roleId).Name;
            }

            return View(users);
        }

        #region Kullanıcı Silme Bölümü

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.ApplicationUsers.FindAsync(id);
            _context.ApplicationUsers.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        #endregion
    }
}
