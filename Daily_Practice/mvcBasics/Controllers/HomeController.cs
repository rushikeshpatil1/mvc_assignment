using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcBasics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult GetName(int Id)
        {
            var employees = new[] {
                new { Id = 1, name = "rushikesh" },
                new { Id = 2, name = "raj"},
                new { Id = 3, name = "rock"}
            };
            string matchName = null;
            foreach (var item in employees)
            {
                if (item.Id == Id)
                {
                    matchName = item.name;
                }
            }
            return new ContentResult() { Content = matchName, ContentType = "text/plain" };
            // return Content(matchName, "text/plain");
        }

        public ActionResult GetSamplePdf(int Id)
        {
            string fileName = "~/sample" + Id + ".pdf";
            return File(fileName, "application/pdf");
        }

        public ActionResult gitUser(int Id)
        {
            var user = new[] {
                new { Id = 1, name = "rushikesh" },
                new { Id = 2, name = "raj"},
                new { Id = 3, name = "rock"}
            };
            string Url = null;
            foreach (var item in user)
            {
                if (item.Id == Id)
                {
                    Url = "http://www.github.com/user" + Id;
                }
            }
            if (Url == null)
            {
                return Content("Invalid id");
            }
            else
            {
                return Redirect(Url);
            }
        }
    }
}