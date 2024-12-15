﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using webOdev3.Models;

namespace webOdev3.Controllers
{
    public class RandevuController : Controller
    {
        KuaforContext _context=new KuaforContext();

        public IActionResult Index()
        {
            var calisanHizmetler = _context.CalisanUzmanliks
        .Include(cu => cu.Calisanlar)
        .Include(cu => cu.Hizmetler)
        .GroupBy(cu => new { cu.Calisanlar.Ad, cu.Calisanlar.Soyad })
        .Select(g => new CalisanHizmetViewModel
        {
            CalisanAdi = g.Key.Ad,
            CalisanSoyadi = g.Key.Soyad,
            HizmetDetaylari = g.Select(x => new HizmetDetayViewModel
            {
                Ad = x.Hizmetler.Ad,
                Sure = x.Hizmetler.Sure,
                Ucret = x.Hizmetler.Ucret
            }).ToList()
        })
        .ToList();

            if (!calisanHizmetler.Any())
            {
                ViewBag.Message = "Henüz eklenmiş bir çalışan veya hizmet yok.";
                return View();
            }

            return View(calisanHizmetler);
        }
         public IActionResult RandevuOlustur()
         {  
            return View();
         }
    }
 }

