using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreIntro.Models;
using AspNetCoreIntro.Data;

namespace AspNetCoreIntro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext applicationDbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = applicationDbContext;
        }

        //[HttpGet("/{username}")]
        public IActionResult Index(string username)
        {
            if (!ModelState.IsValid)
            {

            }


            //ViewBag.Message = "Hello";

            //ViewData["Message"] = "Hello!";

            var listOfPeople = new List<Person>
            {
                new Person { Name = "Gosho" },
                new Person { Name = "Pesho" }
            };

            return View(listOfPeople);

            //return Content("Test!");

            //return Json(new { username = "Pesho" });

            //string path = @"D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\02. ASP-NET CORE INTRODUCTION\dims.jpg";
            //return PhysicalFile(path, "image/jpeg");

            //return RedirectToAction("Add", "Dogs");

            //return Content(username);
        }


        [HttpPost]
        public IActionResult Add(string username)
        {
            return Content(username);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
