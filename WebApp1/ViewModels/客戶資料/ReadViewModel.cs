using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.ViewModels.客戶資料
{
    public class ReadViewModel
    {
        public SearchCondition Condition { get; set; }

        public IList<Models.客戶資料> CustomerList { get; set; }

        public class SearchCondition
        {
            public string 客戶名稱 { get; set; }

            public string 統一編號 { get; set; }

            public string 電話 { get; set; }
        }
    }
}