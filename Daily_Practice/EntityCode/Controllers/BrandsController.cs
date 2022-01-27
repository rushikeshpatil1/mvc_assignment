using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityCode.Models;

namespace EntityCode.Controllers
{
    public class BrandsController : Controller

    {

        CodeContext db = new CodeContext();
        // GET: Brands/Index
        public ActionResult Index()
        {
         
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}