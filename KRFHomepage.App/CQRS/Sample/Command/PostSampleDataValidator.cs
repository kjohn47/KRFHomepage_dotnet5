using FluentValidation;
using KRFCommon.CQRS.Validator;
using KRFHomepage.Domain.CQRS.Sample.Command;
using System.Net;

namespace KRFHomepage.App.CQRS.Sample.Command
{
    public class PostSampleDataValidator: KRFValidator<SampleCommandInput>, IKRFValidator<SampleCommandInput>
    {
        public PostSampleDataValidator(): base()
        {
            this.RuleFor(r => r.SomeInt)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode(HttpStatusCode.BadRequest.ToString())
                .WithMessage("Value must be greater or equal to 0");
            this.RuleFor(r => r.SomeString)
                .NotNull()
                .WithErrorCode(HttpStatusCode.BadRequest.ToString())
                .WithMessage("Value cannot be null")
                .NotEmpty()
                .WithErrorCode(HttpStatusCode.OK.ToString())
                .WithMessage("Value cannot be empty");
        }
    }
}
