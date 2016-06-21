using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeWork4.Models
{
    public class Customer
    {
        [Required]
        [Display(Name = "Customer ID")]
        public int customerid { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string fname { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string lname { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string country { get; set; }

        [Required]
        [Display(Name = "State")]
        public string state { get; set; }

        [Required]
        [Display(Name = "Memeber_Since")]
        public int member_since { get; set; }

        [Required]
        [Display(Name = "ContactDetail")]
        public decimal Contact{ get; set; }
    }
}