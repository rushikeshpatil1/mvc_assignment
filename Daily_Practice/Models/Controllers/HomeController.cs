using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace Models.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()

        {
            List<model> m = new List<model>()
            {
                new model(){id=1,name="Rushikesh" },
                new model(){id=2,name="RP"},
                 new model(){id=3,name="patil"}
            };
            ViewBag.model = m;
            return View();
        }

        public ActionResult Details(int id)
        {
            List<model> m = new List<model>()
            {
                new model(){id=1,name="Rushikesh" },
                new model(){id=2,name="RP"},
                 new model(){id=3,name="patil"}
            };
            model match = null;
            foreach (var item in m)
            {
                if (item.id == id)
                {
                    match = item;
                }
            }
            ViewBag.match = match;
            return View();
        }
    }
}