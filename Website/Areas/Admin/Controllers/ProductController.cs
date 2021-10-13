using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        //GET: Admin/Product
        private Entities _db = new Entities();
        public ActionResult Index()
        {
            var data = (from s in _db.products select s).ToList();
            ViewBag.products = data;
            return View();
        }

        public ActionResult Store()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(product p)
        {
            if (ModelState.IsValid)
            {
                var pro_name = p.pro_name;
                var count = _db.products.Where(s => s.pro_name.Contains(pro_name)).Count();
                if (count > 0)
                {
                    ViewBag.message = "San pham da ton tai";
                    return View();
                }
                p.pro_author_id =1;
                p.created_at = DateTime.Now;
                p.updated_at = DateTime.Now;
                _db.products.Add(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.message = "Them san pham that bai";
            return View();

        }

        public ActionResult Edit(int id)
        {
            var data = _db.products.Where(s => s.id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id , pro_number, Updated_at")] product p)
        {

            if (ModelState.IsValid)
            {
                var data = _db.products.Find(p.id);
                data.pro_number = p.pro_number;
                data.updated_at = DateTime.Now;
                _db.Entry(data).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            var dataEdit = _db.products.Where(s => s.id == p.id).FirstOrDefault();
            return View(dataEdit);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var product = _db.products.Where(s => s.id == id).First();
            _db.products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}