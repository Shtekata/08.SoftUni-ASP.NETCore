using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MyFirstAspNetCoreApp.Filters
{
    public class MyResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            //context.Result = new RedirectToActionResult("Privacy", "Home", new { });
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}
