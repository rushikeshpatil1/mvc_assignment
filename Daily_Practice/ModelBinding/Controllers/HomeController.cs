using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

   /*     [HttpPost]
        public ActionResult Create(Class1 c)
        {
            return View();
        }*/

        [HttpPost]
        public ActionResult Create([Bind(Include = "id")] Class1 c)
        {
            return View();
        }
    }
}