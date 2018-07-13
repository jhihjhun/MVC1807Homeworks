using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.ViewModels.客戶聯絡人
{
    public class ReadViewModel
    {
        public List<Models.客戶聯絡人> CustomerContactList { get; set; }

        public class SearchCondition
        {
            public int? 客戶Id { get; set; }

            public string 職稱 { get; set; }

        }
    }
}