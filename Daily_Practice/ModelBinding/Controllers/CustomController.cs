using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBinding.Models;
namespace ModelBinding.Controllers
{
    public class CustomController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(customBind))] Class1 c)
        {
            return View();
        }
    }
}