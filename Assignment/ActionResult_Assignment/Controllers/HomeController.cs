using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionResult_Assignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string input)
        {
    
            if (input == "sample")
            {
                return File("~/Sample.pdf", "application/pdf");
            }
            else if (input == "gotoabout")
            {
                return RedirectToAction("About");
            }

            else if (input == "login")
            {
                return View("Login");
            }
            else
            {
                return Content("You entered value" + input);
            }
        }

        // GET: Home/About
        public ActionResult About()
        {
            return Content("about action method content");
        }
    }
}