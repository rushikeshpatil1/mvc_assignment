using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace http.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalApplicationPath = Request.PhysicalApplicationPath;
            ViewBag.Path = Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString["parameter"];
            ViewBag.Headers = Request.Headers["Accept"];
            ViewBag.HttpMethod = Request.HttpMethod;
            return View();
        }

        public ActionResult httpresponse()
        {
            Response.Write("Hello from httpResponse");
            Response.ContentType = "text/html";
            Response.Headers["Server"] = "rushikesh Server";
            Response.StatusCode = 500;
            return View();
        }
    }
}