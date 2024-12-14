using System.ComponentModel.DataAnnotations;

namespace webOdev3.Models
{
    public class SifremiUnuttumViewModel
    {

        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }

    }
}
