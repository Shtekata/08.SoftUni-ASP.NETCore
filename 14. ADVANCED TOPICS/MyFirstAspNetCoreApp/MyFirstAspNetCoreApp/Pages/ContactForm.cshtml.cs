using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstAspNetCoreApp.Services;

namespace MyFirstAspNetCoreApp.Pages
{
    public class ContactFormModel : PageModel
    {
        private readonly ICountInstancesService countInstancesService;

        public ContactFormModel(ICountInstancesService countInstancesService)
        {
            this.countInstancesService = countInstancesService;
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [Required]
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }

        [Required]
        [BindProperty]
        public new string Content { get; set; }

        public string InfoMessage { get; set; }

        public void OnGet(string name)
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                InfoMessage = "Thank you for submitting the contact form.";
                // TODO: Send mail
                // TODO: Save to database
                return Redirect("/");
            }
            return Page();
        }

        public override /*async*/ Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            // Before page handler
            return base.OnPageHandlerExecutionAsync(context, next);// await next();
            // After page handler
        }
    }
}