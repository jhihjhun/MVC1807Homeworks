using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApp1.Helpers.ValidationAttributes;

namespace WebApp1.ViewModels.客戶聯絡人
{
    public class CreateViewModel : IValidatableObject
    {
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

        [MobileFormat(ErrorMessage = "格式 : 0900-123456")]
        public string 手機 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool emailExist;

            using (Models.客戶資料Entities db = new Models.客戶資料Entities())
            {
                var customerContact = db.客戶聯絡人.Where(x => x.客戶Id == 客戶Id && x.刪除 == false).ToList();

                emailExist = customerContact.Any(x => x.Email == Email);
            }

            if (emailExist)
            {
                yield return new ValidationResult("同一個客戶Email不得重複.", new[] { "Email" });
            }
        }
    }
}