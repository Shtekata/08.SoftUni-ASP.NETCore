using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApp.Services;
using MyFirstAspNetCoreApp.ViewModels.NavBar;

namespace MyFirstAspNetCoreApp.ViewComponents
{
    //[ViewComponent(Name ="NavBar")]
    public class NavBarViewComponent : ViewComponent
    {
        private readonly IYearsService yearsService;

        public NavBarViewComponent(IYearsService yearsService)
        {
            this.yearsService = yearsService;
        }

        //public IViewComponentResult Invoke()
        //{
        //    var viewModel = new NavBarViewModel();
        //    viewModel.Years = yearsService.GetLastYears(5);
        //    return View(viewModel);
        //}

        public IViewComponentResult Invoke(int count)
        {
            var viewModel = new NavBarViewModel
            {
                Years = yearsService.GetLastYears(count)
            };
            return View(viewModel);
        }
    }
}
