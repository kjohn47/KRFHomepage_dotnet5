using KRFCommon.Context;
using KRFCommon.Swagger;
using KRFHomepage.App.Common;
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
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this._apiName = configuration["AppConfiguration:ApiName"];
            this._tokenIdentifier = configuration["AppConfiguration:TokenIdentifier"];
            this._tokenKey = configuration["AppConfiguration:TokenKey"];
        }

        private readonly string _apiName;
        private readonly string _tokenIdentifier;
        private readonly string _tokenKey;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InjectUserContext.InjectContext(services, _tokenIdentifier, _tokenKey);

            services.AddControllers();

            SwaggerInit.ServiceInit(services, _apiName, _tokenIdentifier);

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

            SwaggerInit.Configure(app, _apiName);
        }
    }
}