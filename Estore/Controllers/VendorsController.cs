using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Estore.Models;
using PagedList.Mvc;
using PagedList;
using System.IO;

namespace Estore.Controllers
{
    public class VendorsController : Controller
    {
        EstoreContext db = new EstoreContext();
        // GET: Vendors
        public ActionResult Index(string SortColumn = "VendorName", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            List<vendors> vendors = db.vendors.ToList();


            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (ViewBag.SortColumn == "VendorID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    vendors = vendors.OrderBy(temp => temp.VendorID).ToList();
                else
                    vendors = vendors.OrderByDescending(temp => temp.VendorID).ToList();
            }
            else if (ViewBag.SortColumn == "VendorName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    vendors = vendors.OrderBy(temp => temp.VendorName).ToList();
                else
                    vendors = vendors.OrderByDescending(temp => temp.VendorName).ToList();
            }
            else if (ViewBag.SortColumn == "Email")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    vendors = vendors.OrderBy(temp => temp.Email).ToList();
                else
                    vendors = vendors.OrderByDescending(temp => temp.Email).ToList();
            }
            else if (ViewBag.SortColumn == "Contact")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    vendors = vendors.OrderBy(temp => temp.Contact).ToList();
                else
                    vendors = vendors.OrderByDescending(temp => temp.Contact).ToList();
            }
            else if (ViewBag.SortColumn == "Address")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    vendors = vendors.OrderBy(temp => temp.Address).ToList();
                else
                    vendors = vendors.OrderByDescending(temp => temp.Address).ToList();
            }


            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(vendors.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            vendors = vendors.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

            return View(vendors);
        }



        public ActionResult Details(long id)
        {
            vendors vendor = db.vendors.Where(temp => temp.VendorID == id).FirstOrDefault();
            return View(vendor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(vendors vendor)
        {
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                vendor.Photo = base64String;
            }



            db.vendors.Add(vendor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(long id)
        {
            vendors existingProduct = db.vendors.Where(temp => temp.VendorID == id).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(vendors ven)
        {



          
           

            vendors existingProduct = db.vendors.Where(temp => temp.VendorID == ven.VendorID).FirstOrDefault();
            existingProduct.VendorName = ven.VendorName;
            existingProduct.Address = ven.Address;
            existingProduct.Contact = ven.Contact;
            existingProduct.Email = ven.Email;



            var file = Request.Files[0];
            var imgBytes = new Byte[file.ContentLength];
            file.InputStream.Read(imgBytes, 0, file.ContentLength);
            var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
            ven.Photo = base64String;


            existingProduct.Photo = ven.Photo;

            db.SaveChanges();
            return RedirectToAction("index", "vendors");
        }

        /*  public ActionResult Delete(long id)
          {
              vendors existingProduct = db.vendors.Where(temp => temp.VendorID == id).FirstOrDefault();
              return View(existingProduct);
          }*/

        /*   [Route("vendors/delete/{id}")]

           public ActionResult Delete(long id)
           {
               vendors existingProduct = db.vendors.Where(temp => temp.VendorID == id).FirstOrDefault();
               db.vendors.Remove(existingProduct);
               db.SaveChanges();
               return RedirectToAction("index", "vendors");
           }*/
        public JsonResult Delete(long id)
        {
            bool result = false;

            vendors pr = db.vendors.Where(temp => temp.VendorID == id).FirstOrDefault();
            db.vendors.Remove(pr);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}