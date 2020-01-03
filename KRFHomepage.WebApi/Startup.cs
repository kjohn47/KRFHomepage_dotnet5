using KRFCommon.Context;
using KRFCommon.Swagger;
using KRFHomepage.App.Constants;
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
            this._apiName = configuration[AppConstants.AppName_Key];
            this._tokenIdentifier = configuration[AppConstants.TokenIdentifier_Key];
            this._tokenKey = configuration[AppConstants.TokenKey_Key];
        }

        private readonly string _apiName;
        private readonly string _tokenIdentifier;
        private readonly string _tokenKey;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InjectUserContext.InjectContext(services, this._tokenIdentifier, this._tokenKey);

            services.AddControllers();

            SwaggerInit.ServiceInit(services, this._apiName, this._tokenIdentifier);

            AppDBContextInjection.InjectDBContext(services, this.Configuration.GetConnectionString(AppConstants.DefaultConStr));
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

            SwaggerInit.Configure(app, this._apiName);

            AppDBContextInjection.ConfigureDBContext(app);
        }
    }
}