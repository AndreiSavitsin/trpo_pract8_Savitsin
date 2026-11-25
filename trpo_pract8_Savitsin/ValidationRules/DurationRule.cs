using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace trpo_pract8_Savitsin.ValidationRules
{
    public class DurationRule : ValidationRule 
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? string.Empty).ToString().Trim();
            if (!int.TryParse(input, out int minutes) || minutes <= 0)
            {
                return new ValidationResult(false, "Продолжительность должна быть целым число > 0");
            }
            return ValidationResult.ValidResult;
        }
    }
}
