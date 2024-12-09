﻿using System.ComponentModel.DataAnnotations;

namespace webOdev3.Models
{
    public class CalisanUzmanlik
    {
        [Key]
        public int CalisanUzmanlikID { get; set; }
        public int CalisanlarID { get; set; }
        public int HizmetlerID { get; set; }

        public Calisanlar Calisanlar { get; set; }
        public virtual Hizmetler Hizmetler { get; set; }
    }
}
