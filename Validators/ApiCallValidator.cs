using FluentValidation;

namespace ioLabsApi.Validators
{
    public class ApiCallValidator : AbstractValidator<ApiCall>
    {
        public ApiCallValidator()
        {
            RuleFor(x => x.Request).NotEmpty().WithMessage("Request cannot be empty");
        }
    }

}
