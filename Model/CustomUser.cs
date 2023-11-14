
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class CustomUser : IdentityUser
    {
        public CustomUser()
        {
            IsActive = true;
        }
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required(ErrorMessage = "E-posta adresinizi giriniz")]
        [DisplayName("E-posta")]
        [RegularExpression(@"^[a-z0-9._-]+(@gmail\@mail\.com)$",
             ErrorMessage = "Lütfen geçerli bir mail adresi giriniz")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        [DisplayName("Şifre")]
        [RegularExpression(@"^[a-z0-9.]*$", ErrorMessage = "Şifreniz büyük harf veya özel karakter içermemelidir.")]
        public string Password { get; set; }

        public bool IsActive { get; set; }

    }
}
