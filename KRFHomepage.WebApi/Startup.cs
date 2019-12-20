using KRFCommon.Context;
using KRFHomepage.App.Injection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace KRFHomepage.WebApi
{
    public class Startup
    {
        private const string apiName = "KRFHomepage";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InjectUserContext.InjectContext(services);

            services.AddControllers();

            services.AddSwaggerGen(option =>
           {
               option.AddSecurityDefinition( "Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
               {
                   In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                   Description = "Place Access Bearer JWT Token",
                   Name = "AccessToken",
                   Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
               });

               option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
               {
                   { 
                       new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                       {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                       }, 
                       new List<string>()
                   }
               });

               option.SwaggerDoc(apiName, new Microsoft.OpenApi.Models.OpenApiInfo
               {
                   Version = "v1",
                   Title = apiName,
                   Description = string.Format("{0} API Swagger", apiName)
               });
           });

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(option => option.SwaggerEndpoint(string.Format("/swagger/{0}/swagger.json", apiName), apiName));
        }
    }
}
