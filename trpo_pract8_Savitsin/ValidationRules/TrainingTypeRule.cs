using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace trpo_pract8_Savitsin.ValidationRules
{
    public class TrainingTypeRule :ValidationRule
    {
        private static readonly string[] Types =
        {
            "Силовая",
            "Кардио",
            "Функциональная",
            "Интервальная",
            "Восстановительная"
        };

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? string.Empty).ToString().Trim();
            if (!Types.Contains(input))
            {
                return new ValidationResult(false, "Выберите допустимый тип тренировки");
            }
            return ValidationResult.ValidResult;
        }
    }
}
