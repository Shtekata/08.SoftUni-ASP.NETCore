namespace ForumSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using ForumSystem.Services.Messaging;
    using Microsoft.AspNetCore.Mvc;

    public class EmailController : BaseController
    {
        private readonly IEmailSender sender;

        public EmailController(IEmailSender sender)
        {
            this.sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            await this.sender.SendEmailAsync("gesheval@gmail.com", "Asen", "siichon.siichon@gmail.com", "Hello", "<h1>Hi</h1>");
            return this.Redirect("/");
        }
    }
}
