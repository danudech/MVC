using ASPCoinMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPCoinMaster.Controllers
{
    public class MasterController : Controller
    {
        private DataClasses1DataContext db;
        // GET: Master
        public MasterController() {
            db = new DataClasses1DataContext();
        }
        public ActionResult login()
        {
            HttpCookie reqcookie = Request.Cookies["loginUser"];
            if (reqcookie != null)
            {
                return Index();
            }
            ViewBag.title = "CoinMaster";
            return View();
        }
        public ActionResult Signup()
        {
            ViewBag.title = "CoinMaster";
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.title = "CoinMaster";
            return View();
        }

        [HttpPost]
        public JsonResult Getdatalogin() {
            return Json(new
            {
                ModuleName = "New Prospective",
                titlelogin = "Sign UP"
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult signup(MasterModels M000)
        {
            return Json(new { id = 0, val = M000.signup(db) }, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public ActionResult Checklogin() {
            HttpCookie reqcookie = Request.Cookies["loginUser"];
            if (reqcookie != null) {
                return PartialView("_Logout");
            }
            return PartialView("_Login");
        }
    }
}