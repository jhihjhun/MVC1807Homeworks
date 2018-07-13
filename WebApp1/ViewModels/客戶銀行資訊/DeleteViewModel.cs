using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.ViewModels.客戶銀行資訊
{
    public class DeleteViewModel
    {
        public int Id { get; set; }

        public int 客戶Id { get; set; }

        public string 銀行名稱 { get; set; }

        public int 銀行代碼 { get; set; }

        public Nullable<int> 分行代碼 { get; set; }

        public string 帳戶名稱 { get; set; }

        public string 帳戶號碼 { get; set; }
    }
}