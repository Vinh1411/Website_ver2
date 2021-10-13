using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class LoginAndRegisterController : Controller
    {
        private Entities _db = new Entities();
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(admin admin)
        {
            if (ModelState.IsValid)
            {
                var check = _db.admins.FirstOrDefault(s => s.email == admin.email);
                if (check == null)
                {
                    if (admin.password == admin.ConfirmPassword)
                    {
                        admin.created_at = DateTime.Now;
                        admin.updated_at = DateTime.Now;
                        _db.Configuration.ValidateOnSaveEnabled = false;
                        _db.admins.Add(admin);
                        _db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.errorConfirm = "Mat khau xac thuc khong dung";
                        return View();
                    }
                }
                else
                {
                    ViewBag.errorEmail = "Email da ton tai";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = password;
                var data = _db.admins.Where(s => s.email.Equals(email) && s.password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().name;
                    Session["Email"] = data.FirstOrDefault().email;
                    Session["id"] = data.FirstOrDefault().id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}