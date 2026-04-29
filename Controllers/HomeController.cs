using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class HomeController : Controller
    {

        ProductContext s2 = new ProductContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Addproduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addproduct(Product p1)
        {
            s2.products.Add(p1);
            s2.SaveChanges();
            return View();
        }

        public ActionResult ViewProduct()
        {

            var x = s2.products.ToList();
            s2.SaveChanges();
            return View(x);
        }

        public ActionResult DelProduct(int id)
        {

            var x = s2.products.Find(id);
            s2.products.Remove(x);
            s2.SaveChanges();
            return RedirectToAction("ViewProduct");
        }

        public ActionResult EditProduct(int id)
        {
            var x = s2.products.Find(id);
            return View(x);
        }

        [HttpPost]
        public ActionResult EditProduct(Product p3)
        {
            if (p3.pid == 0)
            {
                return Content("ID not coming from form");
            }

            var newrecord = s2.products.Find(p3.pid);

            if (newrecord == null)
            {
                return Content("Record not found in DB");
            }

            newrecord.pname = p3.pname;
            newrecord.pcatagory = p3.pcatagory;
            newrecord.pprice = p3.pprice;
            newrecord.pqty = p3.pqty;
            newrecord.pdesc = p3.pdesc;

            s2.SaveChanges();

            return RedirectToAction("ViewProduct");
        }
    }
}