using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult contact()
        {
            ViewBag.message = "from home Controller";
            return View();
        }
    }
}