using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusiCodeWebApp.Models
{
    public class Brand : Entity
    {
        public Brand()
        {
            IsDeleted = false;
            IsActive = true;
        }
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        [StringLength(maximumLength: 200, ErrorMessage = "Bu alan en fazla 200 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Telefon Numarası")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "Telefon numarası 11 karakter olmalıdır")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
    }
}