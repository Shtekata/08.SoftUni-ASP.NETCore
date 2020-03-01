using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewaresDemo.Middlewares
{
    public class RedirectToGoogleIfNotHttpsMiddleware
    {
        private readonly RequestDelegate next;

        public RedirectToGoogleIfNotHttpsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.IsHttps)
            {
                context.Response.StatusCode = 307;
                context.Response.Headers["Location"] = "https://google.com";
            }
            else
            {
                await next(context);
            }
        }
    }
}
