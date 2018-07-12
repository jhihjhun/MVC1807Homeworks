using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.Controllers
{
    public class CustomerController : AbsBaseController
    {
        public ActionResult Index()
        {
            var viewModel = new ViewModels.客戶資料.ReadViewModel();

            using (_db = new Models.客戶資料Entities())
            {
                var data = _db.客戶資料.ToList();

                viewModel.CustomerList = data;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ViewModels.客戶資料.ReadViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}