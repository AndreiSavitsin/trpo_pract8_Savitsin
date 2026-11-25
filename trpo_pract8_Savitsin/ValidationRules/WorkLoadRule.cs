using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace trpo_pract8_Savitsin.ValidationRules
{
    public class WorkLoadRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? string.Empty).ToString().Trim();

            if (input.Length < 3)
            {
                return new ValidationResult(false, "Нагрузка должна содержать от трех символов");
            }
            return ValidationResult.ValidResult;
        }
    }
}
