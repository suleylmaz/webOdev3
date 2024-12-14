﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult RandevuAl()
        {
            // Kullanıcı giriş yapmamışsa, giriş yap sayfasına yönlendir
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                return RedirectToAction("GirisYap", "Home");
            }

            // Kullanıcı giriş yaptıysa, RandevuController'a yönlendir
            return RedirectToAction("Index", "Randevu");
        }
    

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult GirisYap(Kullanicilar g)
        {
            // Kullanıcıyı veritabanında sorgula
            var bilgiler = c.Kullanicilars.FirstOrDefault(x => x.Email == g.Email && x.Sifre == g.Sifre);

            if (bilgiler != null)
            {
                // Kullanıcı başarıyla giriş yaptıysa, kullanıcının email bilgisini Session'a kaydet
                HttpContext.Session.SetString("Email", g.Email);

                // Giriş başarılı ise, ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }

            // Giriş başarısızsa, giriş sayfasını yeniden göster
            TempData["ErrorMessage"] = "Geçersiz email veya şifre."; // Hata mesajı göstermek için TempData
            return View();
        }


        [HttpGet]
        public IActionResult SifremiUnuttum()
        {
            // Boş bir model ile sayfayı döndür
            return View(new SifremiUnuttumViewModel());
        }

        [HttpPost]
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