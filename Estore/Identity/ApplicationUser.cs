using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Estore.Identity
{
    public class ApplicationUser : IdentityUser
    {

        public string userEmail { get; set; }

        public string phone { get; set; }
        public string Address { get; set; }
    }

}