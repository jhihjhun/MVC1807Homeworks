using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.Controllers
{
    public class CustomerContactController : AbsBaseController
    {
        public ActionResult Index()
        {
            var viewModel = new ViewModels.客戶聯絡人.ReadViewModel();

            using (_db = new Models.客戶資料Entities())
            {
                var data = _db.客戶聯絡人.Where(x => x.刪除 == false).ToList();

                viewModel.CustomerContactList = data;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ViewModels.客戶聯絡人.ReadViewModel viewModel)
        {
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModels.客戶聯絡人.CreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var customerContact = new Models.客戶聯絡人
            {
                客戶Id = viewModel.客戶Id,
                職稱 = viewModel.職稱,
                姓名 = viewModel.姓名,
                Email = viewModel.Email,
                手機 = viewModel.手機,
                電話 = viewModel.電話
            };

            using (_db = new Models.客戶資料Entities())
            {
                _db.客戶聯絡人.Add(customerContact);
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

            ViewModels.客戶聯絡人.UpdateViewModel viewModel;

            using (_db = new Models.客戶資料Entities())
            {
                var customerContact = _db.客戶聯絡人.Find(id);

                if (null == customerContact)
                {
                    return HttpNotFound();
                }

                viewModel = new ViewModels.客戶聯絡人.UpdateViewModel
                {
                    Id = customerContact.Id,
                    客戶Id = customerContact.客戶Id,
                    職稱 = customerContact.職稱,
                    姓名 = customerContact.姓名,
                    Email = customerContact.Email,
                    手機 = customerContact.手機,
                    電話 = customerContact.電話
                };
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(ViewModels.客戶聯絡人.UpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (_db = new Models.客戶資料Entities())
            {
                var customerContact = _db.客戶聯絡人.Find(viewModel.Id);

                if (null == customerContact)
                {
                    return HttpNotFound();
                }

                customerContact.職稱 = viewModel.職稱;
                customerContact.姓名 = viewModel.姓名;
                customerContact.Email = viewModel.Email;
                customerContact.手機 = viewModel.手機;
                customerContact.電話 = viewModel.電話;

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

            ViewModels.客戶聯絡人.DetailViewModel viewModel;

            using (_db = new Models.客戶資料Entities())
            {
                var customerContact = _db.客戶聯絡人.Find(id);

                if (null == customerContact)
                {
                    return HttpNotFound();
                }

                viewModel = new ViewModels.客戶聯絡人.DetailViewModel
                {
                    Id = customerContact.Id,
                    客戶Id = customerContact.客戶Id,
                    職稱 = customerContact.職稱,
                    姓名 = customerContact.姓名,
                    Email = customerContact.Email,
                    手機 = customerContact.手機,
                    電話 = customerContact.電話
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

            ViewModels.客戶聯絡人.DeleteViewModel viewModel;

            using (_db = new Models.客戶資料Entities())
            {
                var customerContact = _db.客戶聯絡人.Find(id);

                if (null == customerContact)
                {
                    return HttpNotFound();
                }

                viewModel = new ViewModels.客戶聯絡人.DeleteViewModel
                {
                    Id = customerContact.Id,
                    客戶Id = customerContact.客戶Id,
                    職稱 = customerContact.職稱,
                    姓名 = customerContact.姓名,
                    Email = customerContact.Email,
                    手機 = customerContact.手機,
                    電話 = customerContact.電話
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
                var customerContact = _db.客戶聯絡人.Find(id);

                customerContact.刪除 = true;
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}