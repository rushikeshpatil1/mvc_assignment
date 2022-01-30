using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Validations.Models
{
    [Hobbies(ErrorMessage = "Please Select at least one hobby and maximum of four hobbies")]
    public class user
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool Photography { get; set; }
        public bool Gardening { get; set; }
        public bool Dance { get; set; }
        public bool Hiking { get; set; }
        public bool Painting { get; set; }
    }
}