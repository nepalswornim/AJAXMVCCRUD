using AjaxMVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AjaxMVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private MVCFirstDBEntities _db = new MVCFirstDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Create(tbl_User t)
        {
            tbl_User tb = new tbl_User();
            tb.Username = t.Username;
            tb.FullName = t.FullName;
            tb.Password = t.Password;

            tb.Email = t.Email;
            tb.Contact = t.Contact;
            _db.tbl_User.Add(tb);
            _db.SaveChanges();
            Thread.Sleep(1000);
            List<tbl_User> tbllst = _db.tbl_User.ToList();
            return PartialView("_employee", tbllst);
        }

        public PartialViewResult SelectAll()
        {
            List<tbl_User> tbllst = _db.tbl_User.ToList();
            return PartialView("_employee", tbllst);
        }

        public PartialViewResult SelectTop3()
        {
            Thread.Sleep(1000);
            List<tbl_User> tbllst = _db.tbl_User.OrderByDescending(u => u.UserId).Take(3).ToList();
            return PartialView("_employee", tbllst);
        }

        public PartialViewResult SelectBottom3()
        {
            Thread.Sleep(1000);
            List<tbl_User> tbllst = _db.tbl_User.OrderBy(u => u.UserId).Take(3).ToList();
            return PartialView("_employee", tbllst);
        }
    }
}