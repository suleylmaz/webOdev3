using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using webOdev3.Models;

namespace webOdev3.Controllers
{
    public class KullanicilarController : Controller
    {   
        KuaforContext u=new KuaforContext();

        public IActionResult Index()    
        {
            var kullanicilar=u.Kullanicilars.ToList();
            return View(kullanicilar);
        }
        public IActionResult KullaniciEkle()
        {
            return View();
        }
        public IActionResult KullaniciKaydet(Kullanicilar k)
        {
            if (ModelState.IsValid)
            {
                u.Kullanicilars.Add(k);
                u.SaveChanges();
                TempData["msj"] = k.Ad+ "Kullanıcı Kaydedildi";
                return RedirectToAction("Index");
            }
            TempData["msj"] = "Lütfen Dataları düzgün giriniz";
            return RedirectToAction("KullaniciEkle");

        }
    }
}
