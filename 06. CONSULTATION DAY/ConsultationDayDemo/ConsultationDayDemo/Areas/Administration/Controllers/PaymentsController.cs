namespace ConsultationDayDemo.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
