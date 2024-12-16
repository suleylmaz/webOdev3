using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webOdev3.Models;

namespace webOdev3.Controllers
{
    public class AdminController : Controller
    {
       

        public IActionResult Index()
        {
            KuaforContext c = new KuaforContext();

            // Admin giriş kontrolü
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Email")) ||
                HttpContext.Session.GetString("Email") != "admin@sakarya.edu.tr")
            {
                return RedirectToAction("Index", "Admin");
            }

            // Randevuları, ilişkili tablolarla birlikte yükle
            var randevular = c.Randevulars
                .Include(r => r.Kullanicilar)
                .Include(r => r.Calisanlar)
                .Include(r => r.Hizmetler)
                .Include(r => r.Salon)
                .ToList();

            return View(randevular); // View'e randevu listesini gönder
        }
    }
}
