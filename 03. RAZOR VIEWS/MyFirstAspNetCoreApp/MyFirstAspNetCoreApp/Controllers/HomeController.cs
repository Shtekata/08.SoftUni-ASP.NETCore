using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyFirstAspNetCoreApp.Models;
using MyFirstAspNetCoreApp.Services;
using MyFirstAspNetCoreApp.ViewModels;
using MyFirstAspNetCoreApp.ViewModels.Home;

namespace MyFirstAspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly IStringManipulation stringManipulation;
        private readonly IWebHostEnvironment env;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IStringManipulation stringManipulation, IWebHostEnvironment env)
        {
            _logger = logger;
            this.configuration = configuration;
            this.stringManipulation = stringManipulation;
            this.env = env;
        }

        public IActionResult Index()
        {
            //var a = HttpContext.Request.Headers["User-Agent"];
            this.ViewData["name"] = "Asen";
            ViewData["pinko"] = "Sofia";
            ViewBag.Pinko = "Gosho";
            var viewModel = new IndexViewModel
            {
                Year = DateTime.UtcNow.Year,
                //Message = configuration["YouTube:ApiKey"],
                //Message="<script>alert('AXC')</script>",
                MyMessage="Hello baj Djai",
                Names = new List<string>{ "malko", "ime" },
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return Content(configuration["YouTube:ApiKey"]);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
