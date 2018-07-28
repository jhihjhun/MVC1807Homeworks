using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.Controllers
{
    public class HomeController : AbsBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "LoginError")]
        public ActionResult Login(ViewModels.Home.LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            using (_db = new Models.客戶資料Entities())
            {
                var customer = _db.客戶資料.Where(x => x.帳號 == viewModel.UserName && x.密碼 == viewModel.Password).SingleOrDefault();

                if (null == customer)
                {
                    throw new ArgumentException("登入失敗，帳號或密碼錯誤。");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }


    }
}