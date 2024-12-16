﻿using System.ComponentModel.DataAnnotations;

namespace webOdev3.Models
{
    public class Kullanicilar
    {
        [Key]

        public int KullanicilarID { get; set; }
        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [Display(Name = "E-mail")]
        
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        public List<Randevular> Randevulars { get; set; }
    }

}
