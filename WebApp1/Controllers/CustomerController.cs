﻿using System;
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
    }
}