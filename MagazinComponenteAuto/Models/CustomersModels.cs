using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagazinComponenteAuto.Models
{
    public class CustomersModels
    {
        public Guid CliendID { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [StringLength(100, ErrorMessage = "Max 10 characters")]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [StringLength(100, ErrorMessage = "Max 200 characters")]
        public string Adress { get; set; }

    }
}