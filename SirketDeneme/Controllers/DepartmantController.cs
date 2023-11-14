using AspNetCoreHero.ToastNotification.Abstractions;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Linq;
using System.Threading.Tasks;

namespace SirketDeneme.Controllers
{
    //[Authorize(Roles = "İnsan Kaynakları, Genel Müdür, Genel Müdür Yardımcısı, Admin")]
    public class DepartmantController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        public DepartmantController(ApplicationDbContext db, INotyfService notyf, UserManager<CustomUser> userManager, RoleManager<CustomRole> roleManager)
        {
            _db = db;
            _notyf = notyf;

        }

        public async Task<IActionResult> Index()
        {
            var listele = await _db.Departmant.ToListAsync();
            return View(listele);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departmant departmant)
        {
            _db.Departmant.Add(departmant);
            await _db.SaveChangesAsync();
            _notyf.Success("Departman eklendi");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var guncelle = await _db.Departmant.Where(x => x.DepartmantId == id).FirstOrDefaultAsync();
            return View(guncelle);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departmant departman, int id)
        {
            _db.Update(departman);
            await _db.SaveChangesAsync();
            _notyf.Success("Departman güncellendi");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var sil = await _db.Departmant.Where(X => X.DepartmantId == id).FirstOrDefaultAsync();

            if (sil != null)
            {
                _db.Departmant.Remove(sil);
                await _db.SaveChangesAsync();
                _notyf.Success("Departman silindi");
            }
            else
            {
                _notyf.Error("Departman bulunamadı");
            }
            return RedirectToAction("Index");
        }
    }
}
