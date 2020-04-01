namespace ForumSystem.Web
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();

                        // webBuilder.UseKestrel(x =>
                        // {
                        //     x.AddServerHeader = true;
                        // });
                    })
             .ConfigureLogging(x =>
             {
                 // x.SetMinimumLevel(LogLevel.Information);
                 // x.ClearProviders();
                 // x.AddEventLog();
             });
    }
}
