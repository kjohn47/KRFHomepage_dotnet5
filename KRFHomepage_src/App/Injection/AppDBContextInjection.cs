namespace KRFHomepage.App.Injection
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using KRFHomepage.App.DatabaseQueries;
    using KRFHomepage.Infrastructure.Database.Context;

    public static class AppDBContextInjection
    {
        public static void InjectDBContext(IServiceCollection services, string connectionString, string migrationAssembly, bool useLocalDb = false, string apiDbFolder = null)
        {
            services.AddDbContext<HomepageDBContext>(opt =>
            {
                opt.UseSqlServer(useLocalDb && !string.IsNullOrEmpty(apiDbFolder)
                    ? connectionString.Replace(apiDbFolder, string.Concat(Environment.CurrentDirectory, "\\", apiDbFolder))
                    : connectionString, x =>
                    {
                        x.MigrationsAssembly(migrationAssembly);
                    });
            });

            services.AddScoped( s => new Lazy<IHomepageDatabaseQuery>(() => new HomepageDatabaseQuery(s.GetService<HomepageDBContext>())));
            services.AddScoped( s => new Lazy<ITranslationsDatabaseQuery>(() => new TranslationsDatabaseQuery(s.GetService<HomepageDBContext>())));
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
