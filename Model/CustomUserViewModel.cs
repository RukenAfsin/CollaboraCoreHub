using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class CustomUserViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen ad soyad giriniz")] public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        [DisplayName("Şifre")]
        [RegularExpression(@"^[a-z0-9.]*$", ErrorMessage = "Şifreniz büyük harf veya özel karakter içermemelidir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "E-posta adresinizi giriniz")]
        [DisplayName("E-posta")]
        [RegularExpression(@"^[a-z0-9._-]+(@gmail\@mail\.com)$",
            ErrorMessage = "Lütfen geçerli bir mail adresi giriniz")]
        public string Email { get; set; }

    }
}
