using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstAspNetCoreApp.ModelBinders;
using MyFirstAspNetCoreApp.Services;
using MyFirstAspNetCoreApp.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApp.Controllers
{
    public class Names
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }

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

    public enum CandidateType
    {
        [Display(Name = "Junior Developer")]
        JuniorDeveloper = 1,
        [Display(Name = "Regular Developer")]
        RegularDeveloper = 2,
        [Display(Name = "Senior Developer")]
        SeniorDeveloper = 3,
        [Display(Name = "Junior QA")]
        JuniorQA = 4,
    }
    public class TestController : Controller
    {
        private readonly IPositionsService positionsService;

        //private readonly IYearsService years;

        //public TestController(IYearsService years)
        //{
        //    this.years = years;
        //}
        public TestController(IPositionsService positionsService)
        {
            this.positionsService = positionsService;
        }
        public IActionResult Index()
        {
            var model = new TestInputModel
            {
                Names = new Names
                {
                    FirstName = "Asen",
                    LastName = "Geshev",
                },
                Email = "1@1",
                YearsOfExperience = 7,
                DateOfBirth = new DateTime(1212, 12, 12),
                Egn = "1234567890",
                University = "SoftUni",
                AllTypes = positionsService.GetAll(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TestInputModel input)
        //public IActionResult Index([Bind("Names")]TestInputModel input)
        //public IActionResult Index([FromQuery]TestInputModel input, [FromServices]IYearsService years)
        //public IActionResult Index([FromQuery]TestInputModel input, [FromHeader]string accept)
        {
            if (input.CandidatType3 > 3)
            {
                ModelState.AddModelError(nameof(TestInputModel.CandidatType3), "Invalid...");
            }

            if (!ModelState.IsValid)
            {
                //return Json(ModelState);
                input.AllTypes = positionsService.GetAll();
                return View(input);
            }


            input.AllTypes = positionsService.GetAll();

            var expectedFileExt = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
            var ext = expectedFileExt.FirstOrDefault(x => input.CV.First().FileName.EndsWith(x));
            if (ext != null)
            {
                var filePath = @$"D:\OneDrive\Desktop\user{ext}";
                using var fileStream = new FileStream(filePath, FileMode.Create);
                if (input.CV.First().Length > 1024 * 1024 * 10) { }
                await input.CV.First().CopyToAsync(fileStream);
            }

            //return Json(years.GetLastYears(5));
            //return Json(accept);
            //return Json(input);
            return Redirect("/");
        }

        public IActionResult Download(string filename)
        {
            //System.IO.File.ReadAllBytes();
            //return File();

            var expectedFileExt = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
            var ext = expectedFileExt.FirstOrDefault(x => filename.EndsWith(x));
            if (ext != null)
            {
                var mime = ext switch
                {
                    ".pdf" => "application/pdf",
                    ".doc" => "application/msword",
                    ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    ".xls" => "application/vnd.ms-excel",
                    ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    _ => ""
                };

                var downloadName = ext switch
                {
                    ".pdf" => "Test.pdf",
                    ".doc" => "Test.doc",
                    ".docx" => "Test.docx",
                    ".xls" => "Test.xls",
                    ".xlsx" => "Test.xlsx",
                    _ => ""
                };

                return PhysicalFile($@"D:\OneDrive\Desktop\{filename}", mime, downloadName);
            }
            return null;
        }
    }
}
