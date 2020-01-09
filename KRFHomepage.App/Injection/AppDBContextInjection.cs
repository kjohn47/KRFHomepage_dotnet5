using KRFHomepage.App.DatabaseHelper;
using KRFHomepage.Infrastructure.Database.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KRFHomepage.App.Injection
{
    public static class AppDBContextInjection
    {
        public static void InjectDBContext(IServiceCollection services, string connectionString, string migrationAssembly)
        {
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<HomepageDBContext>(opt =>
            {
                opt.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsAssembly(migrationAssembly);
                });
            });

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
