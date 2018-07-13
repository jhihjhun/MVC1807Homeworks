using System.ComponentModel.DataAnnotations;

namespace WebApp1.ViewModels.客戶聯絡人
{
    public class UpdateViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int 客戶Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 職稱 { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 姓名 { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "欄位長度不得大於 250 個字元")]

        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 手機 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
    }
}