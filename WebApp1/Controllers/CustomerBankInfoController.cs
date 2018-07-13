using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.Controllers
{
    public class CustomerBankInfoController : AbsBaseController
    {
        public ActionResult Index()
        {
            var viewModel = new ViewModels.客戶銀行資訊.ReadViewModel();

            using (_db = new Models.客戶資料Entities())
            {
                var data = _db.客戶銀行資訊.Where(x => x.刪除 == false).ToList();

                viewModel.CustomerBankInfoList = data;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ViewModels.客戶銀行資訊.ReadViewModel viewModel)
        {
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModels.客戶銀行資訊.CreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var customerBankInfo = new Models.客戶銀行資訊
            {
                客戶Id = viewModel.客戶Id,
                銀行名稱 = viewModel.銀行名稱,
                銀行代碼 = viewModel.銀行代碼,
                分行代碼 = viewModel.分行代碼,
                帳戶名稱 = viewModel.帳戶名稱,
                帳戶號碼 = viewModel.帳戶號碼,
            };

            using (_db = new Models.客戶資料Entities())
            {
                _db.客戶銀行資訊.Add(customerBankInfo);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewModels.客戶銀行資訊.UpdateViewModel viewModel;

            using (_db = new Models.客戶資料Entities())
            {
                var customerBankInfo = _db.客戶銀行資訊.Find(id);

                if (null == customerBankInfo)
                {
                    return HttpNotFound();
                }

                viewModel = new ViewModels.客戶銀行資訊.UpdateViewModel
                {
                    Id = customerBankInfo.Id,
                    客戶Id = customerBankInfo.客戶Id,
                    銀行名稱 = customerBankInfo.銀行名稱,
                    銀行代碼 = customerBankInfo.銀行代碼,
                    分行代碼 = customerBankInfo.分行代碼,
                    帳戶名稱 = customerBankInfo.帳戶名稱,
                    帳戶號碼 = customerBankInfo.帳戶號碼
                };
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(ViewModels.客戶銀行資訊.UpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (_db = new Models.客戶資料Entities())
            {
                var customerBankInfo = _db.客戶銀行資訊.Find(viewModel.Id);

                if (null == customerBankInfo)
                {
                    return HttpNotFound();
                }

                customerBankInfo.銀行名稱 = viewModel.銀行名稱;
                customerBankInfo.銀行代碼 = viewModel.銀行代碼;
                customerBankInfo.分行代碼 = viewModel.分行代碼;
                customerBankInfo.帳戶名稱 = viewModel.帳戶名稱;
                customerBankInfo.帳戶號碼 = viewModel.帳戶名稱;

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewModels.客戶銀行資訊.DetailViewModel viewModel;

            using (_db = new Models.客戶資料Entities())
            {
                var customerBankInfo = _db.客戶銀行資訊.Find(id);

                if (null == customerBankInfo)
                {
                    return HttpNotFound();
                }

                viewModel = new ViewModels.客戶銀行資訊.DetailViewModel
                {
                    Id = customerBankInfo.Id,
                    客戶Id = customerBankInfo.客戶Id,
                    銀行名稱 = customerBankInfo.銀行名稱,
                    銀行代碼 = customerBankInfo.銀行代碼,
                    分行代碼 = customerBankInfo.分行代碼,
                    帳戶名稱 = customerBankInfo.帳戶名稱,
                    帳戶號碼 = customerBankInfo.帳戶號碼
                };
            }

            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewModels.客戶銀行資訊.DeleteViewModel viewModel;

            using (_db = new Models.客戶資料Entities())
            {
                var customerBankInfo = _db.客戶銀行資訊.Find(id);

                if (null == customerBankInfo)
                {
                    return HttpNotFound();
                }

                viewModel = new ViewModels.客戶銀行資訊.DeleteViewModel
                {
                    Id = customerBankInfo.Id,
                    客戶Id = customerBankInfo.客戶Id,
                    銀行名稱 = customerBankInfo.銀行名稱,
                    銀行代碼 = customerBankInfo.銀行代碼,
                    分行代碼 = customerBankInfo.分行代碼,
                    帳戶名稱 = customerBankInfo.帳戶名稱,
                    帳戶號碼 = customerBankInfo.帳戶號碼
                };
            }

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (_db = new Models.客戶資料Entities())
            {
                var customerBankInfo = _db.客戶銀行資訊.Find(id);

                customerBankInfo.刪除 = true;
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}