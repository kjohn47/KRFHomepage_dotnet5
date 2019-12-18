using KRFCommon.CQRS.Query;
using KRFHomepage.App.CQRS.Homepage.Query;
using KRFHomepage.Domain.CQRS.Homepage.Query;
using Microsoft.Extensions.DependencyInjection;

namespace KRFHomepage.App.Injection
{
    public static class AppQueryInjection
    {      
        public static void InjectQuery( IServiceCollection services )
        {
            services.AddTransient<IQuery<HomePageInput, HomePageOutput[]>, GetHomePageData>();
        }
    }
}
