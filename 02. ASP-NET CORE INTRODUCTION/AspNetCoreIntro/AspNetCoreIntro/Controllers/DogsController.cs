using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIntro.Controllers
{
    public class DogsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}