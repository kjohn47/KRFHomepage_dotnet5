namespace KRFHomepage.Domain.Common
{
    public class ResponseErrors<TErrorDetails>
    {
        public ResponseErrors(TErrorDetails errorDetails)
        {
            this.HasError = true;
            this.ErrorDetails = errorDetails;
        }

        public bool HasError { get; private set; }
        public TErrorDetails ErrorDetails { get; private set; }
    }
}
