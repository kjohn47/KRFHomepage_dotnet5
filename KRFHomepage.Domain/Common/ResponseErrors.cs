namespace KRFHomepage.Domain.Common
{
    public class ResponseErrors<TErrorDetails>
    {
        public ResponseErrors( TErrorDetails errorDetails, ResponseErrorType errorType)
        {
            this.HasError = true;
            this.ErrorDetails = new ErrorDetails<TErrorDetails>
            {
                Details = errorDetails,
                ErrorType = errorType
            };
        }

        public ResponseErrors()
        {
            this.HasError = false;
        }

        public bool HasError { get; private set; }
        public ErrorDetails<TErrorDetails> ErrorDetails { get; private set; }
    }

    public class ErrorDetails<TErrorDetails>
    {
        public TErrorDetails Details { get; set; }
        public ResponseErrorType ErrorType { get; set; }
    }
}
