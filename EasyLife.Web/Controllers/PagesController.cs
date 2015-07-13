using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyLife.Web.Controllers
{
    public class PagesController : Controller
    {

        public ActionResult SearchResults()
        {
            return View();
        }

        public ActionResult LockScreen()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult InvoicePrint()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserState input)
        {
            if (input.UserName == "admin" && input.PassCode == "123")
            {
                Session["UserState"] = input;
                return RedirectToAction("index", "Home");
            }
            //登陆失败,记录用户名,用户不用重新输入
            ViewData["LoginName"] = input.PassCode;
            //错误提示
            ViewData["ReturnMessage"] = "用户名或者密码错误";
            return View();
        }


        public ActionResult Login_2()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult NotFoundError()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult EmptyPage()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }


    }
}