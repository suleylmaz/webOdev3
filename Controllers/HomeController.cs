using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using webOdev3.Models;

namespace webOdev3.Controllers
{
    public class HomeController : Controller
    {

        KuaforContext c = new KuaforContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        public async Task<IActionResult> GirisYap(Kullanicilar g)
        {
            var bilgiler = c.Kullanicilars.FirstOrDefault(x => x.Email == g.Email && x.Sifre == g.Sifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
               { new Claim(ClaimTypes.Email,g.Email)};
                var useridentity = new ClaimsIdentity(claims, "Home");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Kullanicilar");
            }
            return View();

        }

        [HttpGet]
        public IActionResult SifremiUnuttum(SifremiUnuttumViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Şifre sıfırlama işlemleri
                var user = c.Kullanicilars.FirstOrDefault(x => x.Email == model.Email);
                if (user != null)
                {
                    TempData["Message"] = "Şifre sıfırlama bağlantınız e-posta adresinize gönderildi.";
                }
                else
                {
                    TempData["Message"] = "Bu e-posta adresi sistemde bulunamadı.";
                }
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}