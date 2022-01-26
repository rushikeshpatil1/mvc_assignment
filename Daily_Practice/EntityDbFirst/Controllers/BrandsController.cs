using EntityDbFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityDbFirst.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        DbfirstEntities db = new DbfirstEntities();
        // GET: Products
        public ActionResult Index()
        {
            List<Brand> Brands = db.Brands.ToList();
            return View(Brands);
        }
    }  }