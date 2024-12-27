﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
                HttpContext.Session.GetString("Email") != "b221210033@sakarya.edu.tr")
            {
                return RedirectToAction("Index", "Admin");
            }

            var randevular = c.Randevulars
                 .Include(r => r.Kullanicilar)
                 .Include(r => r.Calisanlar)
                 .Include(r => r.Hizmetler)
                 .Include(r => r.Salon)
                 .Where(r => !r.OnayDurumu) 
                 .OrderByDescending(r => r.Tarih) 
                 .ToList();


            return View(randevular);
        }


        [HttpPost]
        public IActionResult Onayla(int id)
        {
            using (KuaforContext c = new KuaforContext())
            {
                
                var randevu = c.Randevulars.FirstOrDefault(r => r.RandevularID == id);
                if (randevu != null)
                {
                    
                    randevu.OnayDurumu = true;
                    c.SaveChanges();

                    
                    TempData["Message"] = $"Randevu ID: {id} başarıyla onaylandı.";
                }
                else
                {
                    TempData["Message"] = $"Randevu ID: {id} bulunamadı.";
                }
            }

            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CalisanDurumlari()
        {
            using (KuaforContext c = new KuaforContext())
            {
                var calisanKazancListesi = c.Calisanlars
                    .Select(calisan => new
                    {
                        AdSoyad = calisan.Ad + " " + calisan.Soyad,
                        ToplamKazanc = c.Randevulars
                            .Where(r => r.CalisanlarID == calisan.CalisanlarID && r.OnayDurumu)
                            .Sum(r => r.ToplamUcret)
                    })
                    .ToList();

                ViewBag.CalisanKazancListesi = calisanKazancListesi;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Reddet(int id)
        {
            using (KuaforContext c = new KuaforContext())
            {
                
                var randevu = c.Randevulars.FirstOrDefault(r => r.RandevularID == id);
                if (randevu != null)
                {
                    
                    c.Randevulars.Remove(randevu); 
                    c.SaveChanges();

                    
                    TempData["Message"] = $"Randevu ID: {id} reddedildi ve kullanıcıya e-posta gönderildi.";

                }
                else
                {
                    TempData["Message"] = $"Randevu ID: {id} bulunamadı.";
                }
            }

            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Kullanicilar()
        {
            List<Kullanicilar> kullanicilar = new List<Kullanicilar>();

            using (HttpClient client = new HttpClient())
            {
                
                var response = await client.GetAsync("https://localhost:7056/api/KullaniciApi/");

                
                if (response.IsSuccessStatusCode)
                {
                    
                    string jsonData = await response.Content.ReadAsStringAsync();

                    
                    kullanicilar = JsonConvert.DeserializeObject<List<Kullanicilar>>(jsonData);
                }
            }

            
            return View(kullanicilar);
        }
        


    }
}
