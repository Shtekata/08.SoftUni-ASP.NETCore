using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyFirstAspNetCoreApp.ValidationAttributes
{
    public class EgnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Value cannot be null.");
            }

            var valueAsString = value.ToString();
            if (!Regex.IsMatch(valueAsString, "[\\d]{10}"))
            {
                return new ValidationResult("ЕГН-то трябва да съдържа 10 цифри!");
            }

            var weigth = new[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            int checksum = 0;
            for (int i = 0; i < 9; i++)
            {
                checksum += (valueAsString[i] - '0') * weigth[i];
            }

            var lastDigit = checksum % 11;
            if (lastDigit == 10)
            {
                lastDigit = 0;
            }

            if (valueAsString[9] - '0' != lastDigit)
            {
                return new ValidationResult("Егн-то не е валидно!");
            }

            return ValidationResult.Success;
        }
    }
}
