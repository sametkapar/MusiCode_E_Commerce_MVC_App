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
        [StringLength(maximumLength: 75, ErrorMessage = "bu alan en fazla 75 karakter olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}