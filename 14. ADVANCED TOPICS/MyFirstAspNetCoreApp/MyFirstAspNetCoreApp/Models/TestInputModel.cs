using Microsoft.AspNetCore.Http;
using MyFirstAspNetCoreApp.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using MyFirstAspNetCoreApp.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyFirstAspNetCoreApp.Models
{
    public class TestInputModel : IValidatableObject
    {
        //[BindNever]
        //[Range(2000, int.MaxValue)]
        //public int Id { get; set; }

        //[Required]
        public Names Names { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(3)]
        public string University { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        //[StringLength(10, MinimumLength =10)]
        [RegularExpression("[\\d]{10}", ErrorMessage = "Невалидно ЕГН от UI!")]
        [EgnValidation]
        public string Egn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Range(1, int.MaxValue)]
        public int YearsOfExperience { get; set; }

        [Display(Name = "Candidat Type")]
        public CandidateType CandidateType { get; set; }

        [Display(Name = "Candidat Type 2")]
        public int CandidateType2 { get; set; }

        [Display(Name = "Candidat Type 3")]
        public int CandidatType3 { get; set; }

        public IEnumerable<SelectListItem> AllTypes { get; set; }

        public IEnumerable<IFormFile> CV { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (int.Parse(Egn.Substring(0, 2)) != DateOfBirth.Year % 100)
            {
                yield return new ValidationResult("Годината на раждане и ЕГН-то не са валидна комбинация.");
            }
            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult("Passwords do not match!");
            }
        }

        //[ModelBinder(typeof(YearModelBinder))]
        //public int Year { get; set; }

        //public int[] Years { get; set; }
    }
}
