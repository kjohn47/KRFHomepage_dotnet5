using KRFHomepage.App.DatabaseHelper;
using KRFHomepage.Infrastructure.Database.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KRFHomepage.App.Injection
{
    public static class AppDBContextInjection
    {
        public static void InjectDBContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HomepageDBContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.AddLogging( builder => builder.AddConsole().AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information));
            services.BuildServiceProvider().GetService<ILoggerFactory>();
            services.AddScoped<HomepageDatabaseQuery>();
            services.AddScoped<TranslationsDatabaseQuery>();
        }

        public static void ConfigureDBContext( IApplicationBuilder app )
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<HomepageDBContext>().Database.Migrate();
            }
        }
    }
}
