namespace ForumSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
