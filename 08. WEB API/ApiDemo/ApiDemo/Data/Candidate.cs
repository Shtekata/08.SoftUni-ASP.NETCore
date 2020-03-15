using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApiDemo.Data
{
    public class Candidate : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Names { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EgnValidation]
        public string Egn { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Years of experience")]

        public int YearsOfExperience { get; set; }

        public CandidateType CandidateType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (int.Parse(Egn.Substring(0, 2)) != DateOfBirth.Year % 100)
            {
                yield return new ValidationResult("Годината на раждане и ЕГН-то не са валидна комбинация.");
            }
        }
    }

    public class EgnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsString = value?.ToString() ?? "";
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
