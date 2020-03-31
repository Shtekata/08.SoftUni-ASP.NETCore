using Microsoft.AspNetCore.Mvc.Filters;
using MyFirstAspNetCoreApp.Services;
using System;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApp.Filters
{
    public class AddHeaderAsyncActionFilterAttribute : Attribute, IAsyncActionFilter, IAsyncPageFilter
    {
        private readonly string header;
        private readonly string value;

        public AddHeaderAsyncActionFilterAttribute(string header, string value)
        {
            this.header = header;
            this.value = value;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before
            if (DateTime.UtcNow.Second % 2 == 0)
            {
                await next();
            }
            //after
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add(header, value);
            await next();
        }

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            return Task.CompletedTask;
        }
    }

    public class AddHeaderActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IYearsService yearsService;

        //private readonly string header;
        //private readonly string value;

        //public AddHeaderActionFilterAttribute(string header, string value)
        //{
        //    this.header = header;
        //    this.value = value;
        //}
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    context.HttpContext.Response.Headers.Add(header, value);
        //}

        public AddHeaderActionFilterAttribute(IYearsService yearsService)
        {
            this.yearsService = yearsService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Years", string.Join(",", yearsService.GetLastYears(5)));
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
