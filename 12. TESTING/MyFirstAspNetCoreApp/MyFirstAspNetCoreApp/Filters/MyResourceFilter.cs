using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MyFirstAspNetCoreApp.Filters
{
    public class MyResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
