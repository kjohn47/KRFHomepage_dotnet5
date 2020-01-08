using KRFCommon.Context;
using KRFCommon.Handler;
using KRFCommon.Swagger;
using KRFHomepage.App.Constants;
using KRFHomepage.App.Injection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KRFHomepage.WebApi
{
    public class Startup
    {       
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.Configuration = configuration;
            this._apiName = configuration[AppConstants.AppName_Key];
            this._tokenIdentifier = configuration[AppConstants.TokenIdentifier_Key];
            this._tokenKey = configuration[AppConstants.TokenKey_Key];
            this.HostingEnvironment = env;            
        }

        private readonly string _apiName;
        private readonly string _tokenIdentifier;
        private readonly string _tokenKey;

        public IWebHostEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add logger config with sql query detection for dev env
            if (HostingEnvironment.IsDevelopment())
            {
                services.AddLogging(l =>
                {
                    l.ClearProviders();
                    l.AddConsole();
                    l.AddDebug();
                    l.AddEventLog();
                    l.AddEventSourceLogger();
                    l.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
                });
            }

            InjectUserContext.InjectContext(services, this._tokenIdentifier, this._tokenKey);

            services.AddControllers();

            SwaggerInit.ServiceInit(services, this._apiName, this._tokenIdentifier);

            AppDBContextInjection.InjectDBContext(services, this.Configuration.GetConnectionString(AppConstants.DefaultConStr));
            AppQueryInjection.InjectQuery(services);
            AppCommandInjection.InjectCommand(services);
            AppProxyInjection.InjectProxy(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();                
            }

            KRFExceptionHandlerMiddleware.Configure(app, env, loggerFactory, this._apiName, this._tokenIdentifier);

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