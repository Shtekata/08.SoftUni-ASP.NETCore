using Microsoft.AspNetCore.Mvc;

namespace MyFirstAspNetCoreApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index(string id)
        {
            return Content("Bramchilo! : " + id);
        }
    }
}
