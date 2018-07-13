using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApp1.Helpers.ValidationAttributes
{
    public class MobileFormatAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (null == value)
            {
                return true;
            }

            string regPattern = @"\d{4}-\d{6}";

            Regex reg = new Regex(regPattern, RegexOptions.None);

            if (!reg.IsMatch(value.ToString()))
            {
                return false;
            }

            return true;
        }
    }
}