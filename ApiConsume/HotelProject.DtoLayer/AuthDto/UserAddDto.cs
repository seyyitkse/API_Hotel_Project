using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.AuthDto
{
    public class UserAddDto
    {
        [Required(ErrorMessage = "Lütfen kullanıcı ismini giriniz.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcının soy ismini giriniz.")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Lütfen şehir bilgisini giriniz.")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Lütfen mail giriniz.")]
        [StringLength(50)]
        [EmailAddress]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "Şifre 5 karakterden kısa olamaz!")]
        [MaxLength(50, ErrorMessage = "Şifre 50 karakterden uzun olamaz!")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage="Şifreler uyuşmuyor.")]
        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "Şifre 5 karakterden kısa olamaz!")]
        [MaxLength(50, ErrorMessage = "Şifre 50 karakterden uzun olamaz!")]
        public string ConfirmPassword { get; set; }
    }
}
