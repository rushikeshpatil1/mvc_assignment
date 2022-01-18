using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.no = 1;
            ViewBag.name = "rushikesh";
            ViewBag.marks = 60;
            ViewBag.Subjects = 6;
            ViewBag.Remarks = new List<String>() {"A","B","A+" };


            return View();
        }
    }
}