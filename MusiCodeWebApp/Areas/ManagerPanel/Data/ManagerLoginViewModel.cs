using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusiCodeWebApp.Areas.ManagerPanel.Data
{
    public class ManagerLoginViewModel
    {
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 200, MinimumLength = 5, ErrorMessage = "Bu alan 5 - 200 karakter arasında olabilir")]
        public string Mail { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Bu alan 5 - 30 karakter arasında olabilir")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}