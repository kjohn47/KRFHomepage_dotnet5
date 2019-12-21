using KRFCommon.Context;
using KRFCommon.Swagger;
using KRFHomepage.App.Injection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KRFHomepage.WebApi
{
    public class Startup
    {
        private const string apiName = "KRFHomepage";
        private const string tokenIdentifier = "AccessToken";
        private const string tokenKey = "APICOMMONSIGNEDKEY";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InjectUserContext.InjectContext(services, tokenIdentifier, tokenKey);

            services.AddControllers();

            SwaggerInit.ServiceInit(services, apiName, tokenIdentifier);

            AppQueryInjection.InjectQuery(services);
            AppCommandInjection.InjectCommand(services);
            AppProxyInjection.InjectProxy(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            AuthConfigure.Configure(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SwaggerInit.Configure(app, apiName);
        }
    }
}