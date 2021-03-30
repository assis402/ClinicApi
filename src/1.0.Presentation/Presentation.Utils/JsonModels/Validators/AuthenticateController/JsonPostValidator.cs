using FluentValidation;
using Presentation.Utils.Messages;
using Presentation.Utils.JsonModels.Models.AuthenticateController;

namespace Presentation.Utils.JsonModels.Validators.AuthenticateController
{
    public class JsonPostValidator : AbstractValidator<JsonPost>
    {
        public JsonPostValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC011())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC012());

            RuleFor(x => x.TaxNumber)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(JsonPost.TaxNumber)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(JsonPost.TaxNumber)));

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(JsonPost.Password)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(JsonPost.Password)))

                .Length(32)
                .WithMessage(string.Format(ExceptionMessages.EXC017(),nameof(JsonPost.Password)));
        }
    }
}
