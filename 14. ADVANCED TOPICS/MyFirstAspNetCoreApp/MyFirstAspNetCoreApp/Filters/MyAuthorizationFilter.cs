using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MyFirstAspNetCoreApp.Filters
{
    public class MyAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}
