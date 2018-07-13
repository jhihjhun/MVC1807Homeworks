using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                var data = _db.客戶資料.Where(x => x.刪除 == false).ToList();

                viewModel.CustomerList = data;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ViewModels.客戶資料.ReadViewModel viewModel)
        {
            using (_db = new Models.客戶資料Entities())
            {
                var query = _db.客戶資料.AsQueryable();

                if (!string.IsNullOrEmpty(viewModel.Condition.客戶名稱))
                {
                    query = query.Where(x => x.客戶名稱.Contains(viewModel.Condition.客戶名稱));
                }

                if (!string.IsNullOrEmpty(viewModel.Condition.統一編號))
                {
                    query = query.Where(x => x.統一編號.Contains(viewModel.Condition.統一編號));
                }

                if (!string.IsNullOrEmpty(viewModel.Condition.電話))
                {
                    query = query.Where(x => x.電話.Contains(viewModel.Condition.電話));
                }

                query = query.Where(x => x.刪除 == false);

                viewModel.CustomerList = query.OrderBy(x => x.Id).ToList();
            }

            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModels.客戶資料.CreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var customer = new Models.客戶資料
            {
                客戶名稱 = viewModel.客戶名稱,
                統一編號 = viewModel.統一編號,
                電話 = viewModel.電話,
                傳真 = viewModel.傳真,
                地址 = viewModel.地址,
                Email = viewModel.Email,
            };


            using (_db = new Models.客戶資料Entities())
            {
                _db.客戶資料.Add(customer);
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

            ViewModels.客戶資料.UpdateViewModel viewModel;

            using (_db = new Models.客戶資料Entities())
            {
                var customer = _db.客戶資料.Find(id);

                if (null == customer)
                {
                    return HttpNotFound();
                }

                viewModel = new ViewModels.客戶資料.UpdateViewModel
                {
                    Id = customer.Id,
                    客戶名稱 = customer.客戶名稱,
                    統一編號 = customer.統一編號,
                    電話 = customer.電話,
                    傳真 = customer.傳真,
                    地址 = customer.地址,
                    Email = customer.Email
                };
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(ViewModels.客戶資料.UpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (_db = new Models.客戶資料Entities())
            {
                var customer = _db.客戶資料.Find(viewModel.Id);

                if (null == customer)
                {
                    return HttpNotFound();
                }

                customer.客戶名稱 = viewModel.客戶名稱;
                customer.統一編號 = viewModel.統一編號;
                customer.電話 = viewModel.電話;
                customer.傳真 = viewModel.傳真;
                customer.地址 = viewModel.地址;
                customer.Email = viewModel.Email;

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

            ViewModels.客戶資料.DetailViewModel viewModel;

            using (_db = new Models.客戶資料Entities())
            {
                var customer = _db.客戶資料.Find(id);

                if (null == customer)
                {
                    return HttpNotFound();
                }

                viewModel = new ViewModels.客戶資料.DetailViewModel
                {
                    Id = customer.Id,
                    客戶名稱 = customer.客戶名稱,
                    統一編號 = customer.統一編號,
                    電話 = customer.電話,
                    傳真 = customer.傳真,
                    地址 = customer.地址,
                    Email = customer.Email
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

            ViewModels.客戶資料.DeleteViewModel viewModel;

            using (_db = new Models.客戶資料Entities())
            {
                var customer = _db.客戶資料.Find(id);

                if (null == customer)
                {
                    return HttpNotFound();
                }

                viewModel = new ViewModels.客戶資料.DeleteViewModel
                {
                    Id = customer.Id,
                    客戶名稱 = customer.客戶名稱,
                    統一編號 = customer.統一編號,
                    電話 = customer.電話,
                    傳真 = customer.傳真,
                    地址 = customer.地址,
                    Email = customer.Email
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
                var customer = _db.客戶資料.Find(id);

                customer.刪除 = true;
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}