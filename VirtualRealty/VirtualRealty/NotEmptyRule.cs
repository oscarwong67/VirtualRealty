using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VirtualRealty
{
    class NotEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = (string)value;
            if (strValue != null && strValue.Length > 0)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "savedSearchName can't be empty.");
        }
    }
}
