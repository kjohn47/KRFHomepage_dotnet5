using KRFCommon.CQRS.Command;
using KRFHomepage.App.CQRS.Sample.Command;
using KRFHomepage.Domain.CQRS.Sample.Command;
using Microsoft.Extensions.DependencyInjection;

namespace KRFHomepage.App.Injection
{
    public static class AppCommandInjection
    {
        public static void InjectCommand(IServiceCollection services)
        {
            services.AddTransient<ICommand<SampleCommandInput, SampleCommandOutput>, PostSampleData>();
        }
    }
}
