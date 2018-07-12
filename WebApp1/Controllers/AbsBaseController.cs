using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.Controllers
{
    public abstract class AbsBaseController : Controller
    {
        protected Models.客戶資料Entities _db;
    }
}