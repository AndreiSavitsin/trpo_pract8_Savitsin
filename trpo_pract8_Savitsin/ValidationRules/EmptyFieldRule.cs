using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace trpo_pract8_Savitsin.ValidationRules
{
    public class EmptyFieldRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input == string.Empty)
            {
                return new ValidationResult(false, "Поле обязательно для заполнения");
            }
            return ValidationResult.ValidResult;
        }
    }
}
