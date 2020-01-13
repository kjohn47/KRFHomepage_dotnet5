namespace KRFHomepage.App.CQRS.Sample.Command
{
    using KRFCommon.CQRS.Command;
    using KRFCommon.CQRS.Validator;
    using KRFHomepage.Domain.CQRS.Sample.Command;
    using System.Threading.Tasks;

    public class PostSampleData : ICommand<SampleCommandInput, SampleCommandOutput>
    {
        public async Task<CommandValidationError> ExecuteValidationAsync(SampleCommandInput request)
        {
            IKRFValidator<SampleCommandInput> validator = new PostSampleDataValidator();
            return await validator.CheckValidationAsync(request);
        }

        public async Task<SampleCommandOutput> ExecuteCommandAsync(SampleCommandInput request)
        {
            if(request.SomeString.Length > 10)
            {
                return await Task.Run(() => new SampleCommandOutput( new SampleCommandError { Message = "String is too long" }, Domain.Common.ResponseErrorType.Unknown ) );
            }

            return await Task.Run( () => new SampleCommandOutput { SomeIntOut = 2 * request.SomeInt, SomeStringOut = string.Concat("Inputed string: ", request.SomeString) } );
        }
    }
}
