﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyFirstAspNetCoreApp.Filters;
using MyFirstAspNetCoreApp.Models;
using MyFirstAspNetCoreApp.Services;
using MyFirstAspNetCoreApp.ViewModels;
using MyFirstAspNetCoreApp.ViewModels.Home;

namespace MyFirstAspNetCoreApp.Controllers
{
    //[AddHeaderActionFilter("X-Men","Banbino")]
    //[AddHeaderAsyncActionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly IStringManipulation stringManipulation;
        private readonly IWebHostEnvironment env;
        private readonly ICountInstancesService countInstancesService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IStringManipulation stringManipulation, IWebHostEnvironment env, ICountInstancesService countInstancesService)
        {
            _logger = logger;
            this.configuration = configuration;
            this.stringManipulation = stringManipulation;
            this.env = env;
            this.countInstancesService = countInstancesService;
        }

        public IActionResult MyError()
        {
            return Content("ERROR!!!");
        }

        public IActionResult MyNotFound()
        {
            return View();
        }

        public IActionResult HttpError(int ErrorIs)
        {
            if (ErrorIs == 404)
            {
                return View("404", ErrorIs);
            }
            else
            {
                var viewModel = new ErrorViewModel { RequestId = ErrorIs.ToString() };
                return View("Error", viewModel);
            }
        }

        //[Authorize]
        [MyAuthorizationFilter]
        [MyResourceFilter]
        //[AddHeaderActionFilter("X-Men", "Banbino")]
        //[TypeFilter(typeof(AddHeaderActionFilterAttribute))]
        [ServiceFilter(typeof(AddHeaderActionFilterAttribute))]
        [MyExeptionFilter]
        [MyResultFilter]
        public IActionResult Index()
        {
            User.FindFirstValue(ClaimTypes.NameIdentifier);
            //string a = null;
            //a.ToLower();
            _logger.LogInformation(countInstancesService.Instaces.ToString());
            //var a = HttpContext.Request.Headers["User-Agent"];
            this.ViewData["name"] = "Asen";
            ViewData["pinko"] = "Sofia";
            ViewBag.Pinko = "Gosho";
            var viewModel = new IndexViewModel
            {
                Year = DateTime.UtcNow.Year,
                //Message = configuration["YouTube:ApiKey"],
                //Message="<script>alert('AXC')</script>",
                MyMessage = "Hello baj Djai",
                Names = new List<string> { "malko", "ime" },
            };
            return View(viewModel);
        }

        //[AddHeaderActionFilter]
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
