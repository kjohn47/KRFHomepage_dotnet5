namespace KRFHomepage.App.Injection
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    using KRFHomepage.App.DatabaseQueries;
    using KRFHomepage.Infrastructure.Database.Context;
    using KRFCommon.Database;

    public static class AppDBContextInjection
    {
        public static void InjectAppDBContext( this IServiceCollection services, KRFDatabases databaseSettings = null )
        {
            //Context inject
            services.InjectDBContext<HomepageDBContext>( databaseSettings );

            //Inject database query handlers
            services.AddScoped( s => new Lazy<IHomepageDatabaseQuery>( () => new HomepageDatabaseQuery( s.GetService<HomepageDBContext>() ) ) );
            services.AddScoped( s => new Lazy<ITranslationsDatabaseQuery>( () => new TranslationsDatabaseQuery( s.GetService<HomepageDBContext>() ) ) );
        }

        public static void ConfigureAppDBContext( this IApplicationBuilder app, KRFDatabases databaseSettings = null )
        {
            //Inject Migration Automation
            if ( databaseSettings != null && databaseSettings.EnableAutomaticMigration )
            {
                using ( var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope() )
                {
                    serviceScope.ConfigureAutomaticMigrations<HomepageDBContext>();
                }
            }
        }
    }
}
