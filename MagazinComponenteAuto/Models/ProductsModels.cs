using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinComponenteAuto.Models
{
    public class ProductsModels
    {
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [StringLength(200, ErrorMessage = "Max 200 characters")]
        public string ImageName { get; set; }
    }
}