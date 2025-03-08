using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusiCodeWebApp.Models
{
    public class Product:Entity
    {
        public int Brand_ID { get; set; }

        [ForeignKey("Brand_ID")]
        [Display(Name = "Marka Adı")]
        public virtual Brand Brand { get; set; }

        public int Category_ID { get; set; }
        [ForeignKey("Category_ID")]
        [Display(Name = "Kategori Adı")]
        public virtual Category Category { get; set; }


        [Display(Name = "İsim")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır")]
        public string Name { get; set; }
        [Display(Name = "Stok Miktarı")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public int UnitsInStock { get; set; }
        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Satışta mı")]
        public bool IsActive { get; set; }
     
    }
}