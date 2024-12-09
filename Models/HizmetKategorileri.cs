using System.ComponentModel.DataAnnotations;

namespace webOdev3.Models
{
    public class HizmetKategorileri
    {

        [Key]
        public int HizmetKtgID { get; set; }
        public string Ad { get; set; }

        public List<HizmetKategorisiLink> Links { get; set; }
    }
}
