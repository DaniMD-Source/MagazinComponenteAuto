using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinComponenteAuto.Models
{
    public class ShoppingCartModels
    {
        public int ShoppingCartID { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public int ProductCodeID { get; set; }

        public int Quantity { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public decimal Price { get; set; }

    }
}