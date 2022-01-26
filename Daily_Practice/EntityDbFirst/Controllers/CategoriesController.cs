using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDbFirst.Models;
namespace EntityDbFirst.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories

        DbfirstEntities db = new DbfirstEntities();
        public ActionResult Index()
        {
           
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}