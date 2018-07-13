using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.ViewModels.客戶銀行資訊
{
    public class ReadViewModel
    {
        public List<Models.客戶銀行資訊> CustomerBankInfoList { get; set; }

        public class SearchCondition
        {
            public string 客戶Id { get; set; }

            public string 銀行名稱 { get; set; }

            public string 銀行代碼 { get; set; }

        }
    }
}