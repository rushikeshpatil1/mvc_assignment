using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityCode.Models;

namespace EntityCode.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        CodeContext db = new CodeContext();
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
            return View(categories);
            
        }
    }
}