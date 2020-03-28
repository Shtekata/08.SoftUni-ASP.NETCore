using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstAspNetCoreApp.ModelBinders;
using MyFirstAspNetCoreApp.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MyFirstAspNetCoreApp.Models;


namespace MyFirstAspNetCoreApp.Controllers
{
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
            return PartialView(model);
        }

        public IActionResult JsonIndex()
        {
            var model = new
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
            var modelJ = JsonConvert.SerializeObject(model);
            var modelJson = Json(model);
            //modelJson.Value = new { a = "c", b = "d" };

            return modelJson;
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
