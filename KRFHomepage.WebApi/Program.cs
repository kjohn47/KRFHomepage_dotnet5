using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel((c, o) =>
                    {
                        if(c.HostingEnvironment.IsDevelopment())
                        {
                            o.ListenLocalhost(14747, l => l.UseHttps( h => h.AllowAnyClientCertificate()));
                            o.ListenLocalhost(4747);
                        }
                        else
                        {
                            //o.Listen(IPAddress.Any, 14747, l => l.UseHttps( h => h.AllowAnyClientCertificate()));
                            //o.Listen(IPAddress.Any, 4747);
                        }
                    })
                    .UseStartup<Startup>();
                });
    }
}
