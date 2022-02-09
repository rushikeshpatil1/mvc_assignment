using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Estore.Models;

namespace Estore.Controllers
{
    public class ProductsController : Controller
    {
        EstoreContext db = new EstoreContext();
        // GET: products
        public ActionResult Index(string SortColumn = "ProductName", string IconClass = "fa-sort-asc", int PageNo = 1, string proName="", string  proPrice="", string proVen="")
        {
            List<products> products = db.products.ToList();
        
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DateOfPurchase).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "VendorID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.vendors.VendorID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.vendors.VendorID).ToList();
            }
           

        
            int NoOfRecordsPerPage = 4;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();


            if (proName != "" && proPrice != "" && proVen != "")
            {
                List<products> pro = db.products.Where(temp => temp.ProductName.Contains(proName) && temp.Price.ToString().Equals(proPrice) && temp.vendors.VendorName.Contains(proVen)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pro.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.proVen = proVen;
                ViewBag.proPrice = proPrice;
                ViewBag.proName = proName;
                return View(pro);
            }

            else if (proName != "" && proPrice != "")
            {
                List<products> pro = db.products.Where(temp => temp.ProductName.Contains(proName) && temp.Price.ToString().Equals(proPrice)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pro.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.proPrice = proPrice;
                ViewBag.proName = proName;
                return View(pro);
            }

            else if (proName != "" && proVen != "")
            {
                List<products> pro = db.products.Where(temp => temp.ProductName.Contains(proName) && temp.vendors.VendorName.Contains(proVen)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pro.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.proVen = proVen;
                ViewBag.proName = proName;
                return View(pro);
            }

            else if (proName != "")
            {
                List<products> pro = db.products.Where(temp => temp.ProductName.Contains(proName)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pro.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.proName = proName;
                return View(pro);
            }
            else if (proPrice != "")
            {
                List<products> pro = db.products.Where(temp =>  temp.Price.ToString().Equals(proPrice)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pro.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.proPrice = proPrice;
                return View(pro);
            }

            else if (proVen != "")
            {
                List<products> pro = db.products.Where(temp => temp.vendors.VendorName.Contains(proVen)).ToList();
                int NoOfRecPerPage1 = 7;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pro.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (PageNo - 1) * NoOfRecPerPage1;
                ViewBag.pageno = PageNo;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.proVen = proVen;
                return View(pro);
            }



            return View(products);

  
        }



        public ActionResult Details(long id)
        {
            products p = db.products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }

        public ActionResult Create()
        {
            ViewBag.products = db.products.ToList();
            ViewBag.vendors = db.vendors.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(products p)
        {


            if (ModelState.IsValid)
            {
  
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }
                db.products.Add(p);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.products = db.products.ToList();
                ViewBag.vendors = db.vendors.ToList();
                return View();
            }
         
        }

        public ActionResult Edit(long id)
        {
            products existingProduct = db.products.Where(temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.products = db.products.ToList();
            ViewBag.vendors = db.vendors.ToList();
            TempData["photo"] = existingProduct.Photo;
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(products p)
        {
            ViewBag.products = db.products.ToList();
            ViewBag.vendors = db.vendors.ToList();
            products existingProduct = db.products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.VendorID = p.VendorID;
            
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;


            if (p.Photo != null)
            {

                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                p.Photo = base64String;

            }
            else
            {
                string pic = Convert.ToString(TempData["photo"]);
                p.Photo = pic;
            }

            existingProduct.Photo = p.Photo;

            db.SaveChanges();
            return RedirectToAction("index", "products");
        }



        public JsonResult Delete(long id)
        {
            bool result = false;
            products pr = db.products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.products.Remove(pr);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /*
                [HttpPost]
                public ActionResult Delete(long id, products p)
                {
                    products existingProduct = db.products.Where(temp => temp.ProductID == id).FirstOrDefault();
                    db.products.Remove(existingProduct);
                    db.SaveChanges();
                    return RedirectToAction("index", "product");
                }*/
    }






}