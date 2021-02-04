﻿namespace KRFHomepage.App.Injection
{
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;

    using KRFCommon.CQRS.Query;

    using KRFHomepage.App.CQRS.Homepage.Query;
    using KRFHomepage.App.CQRS.Translations.Query;
    using KRFHomepage.Domain.CQRS.Homepage.Query;
    using KRFHomepage.Domain.CQRS.Translations.Query;

    public static class AppQueryInjection
    {      
        public static void InjectQuery( IServiceCollection services )
        {
            services.AddTransient<IQuery<HomePageInput, HomePageOutput>, GetHomePageData>();
            services.AddTransient<IQuery<TranslationRequest, TranslationResponse>, GetAppTranslations>();
        }
    }
}