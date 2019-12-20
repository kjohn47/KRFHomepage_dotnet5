using KRFCommon.Context;
using KRFHomepage.App.Injection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddAuthentication( o => {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("APICOMMONSIGNEDKEY")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = ctx =>
                    {
                        if (ctx.Request.Headers.ContainsKey("AccessToken"))
                        {
                            var bearerToken = ctx.Request.Headers["AccessToken"].ElementAt(0);
                            var token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
                            ctx.Token = token;
                        }
                        else
                        {
                            ctx.NoResult();
                        }
                        return Task.CompletedTask;
                    }
                };
            });
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

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseAuthentication();

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
