using KRFHomepage.Domain.Common;

namespace KRFHomepage.Domain.CQRS.Sample.Command
{
    public class SampleCommandOutput : ResponseErrors<SampleCommandError>
    {
        public int SomeIntOut { get; set; }
        public string SomeStringOut { get; set; }
    }

    public class SampleCommandError
    {       
        public string Message { get; set; }
    }    
}
