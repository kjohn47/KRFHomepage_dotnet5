using KRFHomepage.Domain.Common;

namespace KRFHomepage.Domain.CQRS.Sample.Command
{
    public class SampleCommandOutput : ResponseErrors<SampleCommandError>
    {
        public SampleCommandOutput() { }
        public SampleCommandOutput( SampleCommandError error, ResponseErrorType responseErrorType) : base(error, responseErrorType) { }

        public int SomeIntOut { get; set; }
        public string SomeStringOut { get; set; }
    }

    public class SampleCommandError
    {       
        public string Message { get; set; }
    }    
}
