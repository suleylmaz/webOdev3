using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using webOdev3.Models;

namespace webOdev3.Controllers
{
    public class KullanicilarController : Controller
    {   
       KuaforContext c=new KuaforContext();

        public IActionResult Index()
        {
            //var degerler = c.Kullanicilars.ToList();
            //return View("Index");
          // TempData["Message"] = "Yeni kullanıcı başarıyla eklendi!";
            return RedirectToAction("Index","Home");
        }
       
        public IActionResult KullaniciEkle()
        {
            return View();
        }
     
        public IActionResult KullaniciKaydet(Kullanicilar k)
        { 
            c.Kullanicilars.Add(k);
            c.SaveChanges();
            TempData["Message"] = "Yeni kullanıcı başarıyla eklendi!";
            return RedirectToAction("Index");

        }
    }
}

