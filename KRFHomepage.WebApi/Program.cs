using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KRFHomepage.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)                
                .ConfigureLogging((c,logging) =>
                {
                    if (c.HostingEnvironment.IsDevelopment())
                    {
                        logging.ClearProviders()
                        .AddConsole()
                        .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
                        .AddEventLog();                      
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel((c, o) =>
                    {
                        if(c.HostingEnvironment.IsDevelopment())
                        {
                            o.ListenLocalhost(14747, l => l.UseConnectionLogging().UseHttps( h => h.AllowAnyClientCertificate()));
                            o.ListenLocalhost(4747, l => l.UseConnectionLogging());
                        }
                        //o.Listen(IPAddress.Any, 14747);
                    })
                    .UseStartup<Startup>();
                });
    }
}
