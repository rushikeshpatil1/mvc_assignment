using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace Models.Controllers
{
    public class StrongTypeController : Controller
    {
        // GET: StrongType
        public ActionResult Index()

        {
            List<model2> m = new List<model2>()
            {
                new model2(){id=1,name="Rushikesh" },
                new model2(){id=2,name="RP"},
                 new model2(){id=3,name="patil"}
            };
       
            return View(m);
        }
    }
}