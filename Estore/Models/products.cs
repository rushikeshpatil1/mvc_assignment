using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Estore.Models
{
    public class products
    {
        [Key]
        [Display(Name = "ID")]
        public long ProductID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name can't be blank")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price can't be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Numbers only!")]
        public Nullable<int> Price { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date can't be blank")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }


        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please select availability status")]
        public string AvailabilityStatus { get; set; }


        [Display(Name = "Sold by ")]
        [Required(ErrorMessage = "Please select vendor")]
        public Nullable<long> VendorID { get; set; }

        [Display(Name = "Product Image")]
        public string Photo { get; set; }


        public virtual vendors vendors { get; set; }

    }
}