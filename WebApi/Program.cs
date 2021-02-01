using KRFHomepage.App.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;

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
                        int httpPort = int.Parse(c.Configuration[AppConstants.KestrelConfigurationHttpPort] ?? "4747");
                        int httpsPort = int.Parse(c.Configuration[AppConstants.KestrelConfigurationHttpsPort] ?? "14747");
                        if (c.HostingEnvironment.IsDevelopment())
                        {
                            o.ListenLocalhost(httpsPort, l => l.UseHttps( h => {
                                h.AllowAnyClientCertificate();
                                h.ClientCertificateMode = Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode.NoCertificate;
                            }));
                            o.ListenLocalhost(httpPort);
                        }
                        else
                        {
                            o.Listen(IPAddress.Any, httpsPort, l => l.UseHttps(h => {
                                h.AllowAnyClientCertificate();
                                h.ClientCertificateMode = Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode.NoCertificate;
                            }));
                            o.Listen(IPAddress.Any, httpPort);
                        }
                    })
                    .UseStartup<Startup>();
                });
    }
}
