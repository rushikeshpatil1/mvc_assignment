using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedView.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult contact()
        {
            ViewBag.message = "from main Controller";
            return View();
        }
    }
}