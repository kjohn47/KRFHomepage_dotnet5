namespace KRFHomepage.App.Injection
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    using KRFHomepage.App.DatabaseQueries;
    using KRFHomepage.Infrastructure.Database.Context;
    using KRFCommon.Database;

    public static class AppDBContextInjection
    {
        public static void InjectDBContext(IServiceCollection services, KRFDatabases databaseSettings = null)
        {
            if (databaseSettings != null && databaseSettings.Databases != null && databaseSettings.Databases.Any())
            {
                KRFDbContextInjectHelper.InjectDBContext<HomepageDBContext>(services, databaseSettings.Databases.ElementAt(0), databaseSettings.MigrationAssembly);

                services.AddScoped(s => new Lazy<IHomepageDatabaseQuery>(() => new HomepageDatabaseQuery(s.GetService<HomepageDBContext>())));
                services.AddScoped(s => new Lazy<ITranslationsDatabaseQuery>(() => new TranslationsDatabaseQuery(s.GetService<HomepageDBContext>())));
            }
        }

        public static void ConfigureDBContext( IApplicationBuilder app, KRFDatabases databaseSettings = null)
        {
            if (databaseSettings != null && databaseSettings.EnableAutomaticMigration && databaseSettings.Databases != null)
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    KRFDbContextInjectHelper.ConfigureAutomaticMigrations<HomepageDBContext>(serviceScope);
                }
            }
        }
    }
}
