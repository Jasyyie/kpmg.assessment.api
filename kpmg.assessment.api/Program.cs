using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace kpmg.assessment.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
#if !DEBUG
                    webBuilder.UseUrls("http://+:5000");
#endif
                    webBuilder.UseStartup<Startup>();
                });
    }
}
