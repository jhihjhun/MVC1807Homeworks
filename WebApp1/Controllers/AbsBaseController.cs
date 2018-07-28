using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Helpers.ActionFilters;

namespace WebApp1.Controllers
{
    [ActionTimeLogFilter]
    public abstract class AbsBaseController : Controller
    {
        protected Models.客戶資料Entities _db;
    }
}