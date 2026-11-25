using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace trpo_pract8_Savitsin.ValidationRules
{
    public class DateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Выберите дату тренировки");
            }

            if (value is DateTime date && date.Date > DateTime.Now)
            {
                return new ValidationResult(false, "Дата тренировки не может быть из будущего");
            }

            return ValidationResult.ValidResult;
        }
    }
}
