using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlHelpersEx.Models;

namespace HtmlHelpersEx.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            model1 m = new model1();
            List<model1> l = new List<model1>() {
            new model1(){ id=1,name="Rushikesh"},
            new model1(){ id=2,name="Rp"}
            };
            
            return View(l);
        }
    }
}