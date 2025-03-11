using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusiCodeWebApp.Models
{
    public class Member :Entity
    {
        public Member()
        {
            RegistrationTime = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
            LastLoginTime = DateTime.Now;
        }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "İsim")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olabilir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "Soyisim")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olabilir")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olabilir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "E-Posta")]
        [StringLength(maximumLength: 25, ErrorMessage = "Bu alan en fazla 25 karakter olabilir")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Display(Name = "Şifre")]
        [StringLength(maximumLength: 15, MinimumLength = 8, ErrorMessage = "Bu alan 8 - 15 karakter olabilir")]
        public string Password { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationTime { get; set; }

        [Display(Name = "Son Giriş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastLoginTime { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

    }
}