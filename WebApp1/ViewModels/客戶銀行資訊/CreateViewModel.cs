using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp1.ViewModels.客戶銀行資訊
{
    public class CreateViewModel
    {
        [Required]
        public int 客戶Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 銀行名稱 { get; set; }

        [Required]
        public int 銀行代碼 { get; set; }

        public Nullable<int> 分行代碼 { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 帳戶名稱 { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "欄位長度不得大於 20 個字元")]
        public string 帳戶號碼 { get; set; }
    }
}