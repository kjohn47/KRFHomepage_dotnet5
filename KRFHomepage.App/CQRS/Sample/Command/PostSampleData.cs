namespace KRFHomepage.App.CQRS.Sample.Command
{
    using KRFCommon.CQRS.Command;
    using KRFHomepage.Domain.CQRS.Sample.Command;
    using System.Threading.Tasks;

    public class PostSampleData : ICommand<SampleCommandInput, SampleCommandOutput>
    {
        public Task<SampleCommandOutput> ExecuteCommandAsync(SampleCommandInput request)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommandValidationError> ExecuteValidationAsync(SampleCommandInput request)
        {
            throw new System.NotImplementedException();
        }
    }
}
