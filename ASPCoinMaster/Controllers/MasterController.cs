using ASPCoinMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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
        public ActionResult login(string refer)
        {
            HttpCookie reqcookie = Request.Cookies["loginUser"];
            if (reqcookie != null)
            {
                return Index();
            }
            ViewBag.title = "CoinMaster";
            ViewBag.refer = refer;
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

        //[ChildActionOnly]
        //public ActionResult Checklogin() {
        //    HttpCookie reqcookie = Request.Cookies["loginUser"];
        //    if (reqcookie != null) {
        //        return PartialView("_Logout");
        //    }
        //    return PartialView("_Login");
        //}

        [HttpPost]
        public ActionResult SendEmail(sentEmail mail)
        {


            string clientId = "dany.yotali@gmail.com";
            string clientPass = "dany14521254Ss";
            string to = mail.to;
            string body = mail.body;
            string subject = mail.subject;
            string sentstatus = null;
            
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(clientId);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.To.Add(to);
                mailMessage.IsBodyHtml = false;
                
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential(clientId, clientPass);
                smtp.Send(mailMessage);
                sentstatus = "Sent Success";
            }
            catch (Exception)
            {
                sentstatus = "Sent Error";
            }
            return Json(new { val = sentstatus }, JsonRequestBehavior.AllowGet);
        }
    }
}