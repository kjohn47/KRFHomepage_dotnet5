using KRFCommon.CQRS.Query;
using KRFHomepage.App.CQRS.Homepage.Query;
using KRFHomepage.App.CQRS.Sample.Query;
using KRFHomepage.App.CQRS.Translations.Query;
using KRFHomepage.Domain.CQRS.Homepage.Query;
using KRFHomepage.Domain.CQRS.Sample.Query;
using KRFHomepage.Domain.CQRS.Translations.Query;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace KRFHomepage.App.Injection
{
    public static class AppQueryInjection
    {      
        public static void InjectQuery( IServiceCollection services )
        {
            services.AddTransient<IQuery<SampleInput, SampleOutput[]>, GetSampleData>();
            services.AddTransient<IQuery<HomePageInput, HomePageOutput>, GetHomePageData>();
            services.AddTransient<IQuery<TranslationRequest, Dictionary<string, Dictionary<string, string>>>, GetAppTranslations>();
        }
    }
}
