using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Routing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult product(int? id)
        {
            var products = new[] {
                new { id = 1, name = "laptop"  },
                new { id = 2, name = "desktop"  },
                new { id = 3, name = "mobile" }
            };
            if (id == null)
            {
                return Content("Please pass any product id");
            }
            else
            {
                string name = "";
                foreach (var pro in products)
                {
                    if (pro.id == id)
                    {
                        name = pro.name;
                    }
                }
                return Content(name);
            }

        }



        public ActionResult productString(String id)
        {
            var products = new[] {
                new { id = 1, name = "laptop"  },
                new { id = 2, name = "desktop"  },
                new { id = 3, name = "mobile" }
            };
            if (id == null)
            {
                return Content("Please pass any product name");
            }
            else
            {
                int Id = 0;
                foreach (var p in products)
                {
                    if (p.name == id)
                    {
                        Id = p.id;
                    }
                }
                return Content(Id.ToString());
            }

        }
    }
}