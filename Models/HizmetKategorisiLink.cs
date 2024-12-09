using System.ComponentModel.DataAnnotations;

namespace webOdev3.Models
{
    public class HizmetKategorisiLink
    {
        [Key]
        public int HizmetLinkID { get; set; }
        public int HizmetlerID { get; set; }
        public int HizmetKtgID { get; set; }

        // Navigasyon özellikleri
        public virtual Hizmetler Hizmetler { get; set; }
        public virtual HizmetKategorileri HizmetKategorisileri { get; set; }
    }
}
