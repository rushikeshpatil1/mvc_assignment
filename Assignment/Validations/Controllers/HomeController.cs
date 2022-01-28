using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validations.Models;

namespace Validations.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Registration
        public ActionResult Registration()
        {
            return View();
        }

        // POST: Home/Registration
        [HttpPost]
        public ActionResult Registration(user user)
        {
            if (ModelState.IsValid)
            {
                return Content("Valid");
            }
            else
            {
                return Content("InValid");
            }
        }
        }
    }

