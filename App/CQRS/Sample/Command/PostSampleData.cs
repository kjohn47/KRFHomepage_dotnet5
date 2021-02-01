namespace KRFHomepage.App.CQRS.Sample.Command
{
    using KRFCommon.CQRS.Command;
    using KRFCommon.CQRS.Common;
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

        public async Task<IResponseOut<SampleCommandOutput>> ExecuteCommandAsync(SampleCommandInput request)
        {
            await Task.Yield();
            if(request.SomeString.Length > 10)
            {
                return ResponseOut<SampleCommandOutput>.GenerateFault( new ErrorOut( System.Net.HttpStatusCode.OK, "Value inserted is too long, limit 9 char", ResponseErrorType.Database, "SomeString" ) );
            }

            return ResponseOut<SampleCommandOutput>.GenerateResult( new SampleCommandOutput { SomeIntOut = 2 * request.SomeInt, SomeStringOut = string.Concat("Inputed string: ", request.SomeString) } );
        }
    }
}
