using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinComponenteAuto.Models
{
    public class OrderChartModels
    {
        public int OrderChartID { get; set; }

        [Required(ErrorMessage = "Mandatory")]

        public int ShoppingCartID { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public Guid ClientID { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [StringLength(200, ErrorMessage = "Max 200 characters")]
        public string DeliveryAdress { get; set; }
    }
}