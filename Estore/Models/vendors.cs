using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estore.Models
{
    public class vendors
    {
        [Key]
        public long VendorID { get; set; }


        [Required(ErrorMessage = "Name can't be blank")]
        public string VendorName { get; set; }

        [Required(ErrorMessage = "Address can't be blank")]

        public string Address { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Invalid Email Formate.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact can't be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Numbers only")]
        public string Contact { get; set; }
        public string Photo { get; set; }

    }
}