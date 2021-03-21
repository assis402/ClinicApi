using FluentValidation;
using Presentation.Utils.Messages;
using Presentation.Utils.JsonModels.Models;

namespace Presentation.Utils.JsonModels.Validators
{
    public class JsonGetValidator : AbstractValidator<JsonGet>
    {
        public JsonGetValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC009())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC010());

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC003(nameof(JsonGet.Id)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC004(nameof(JsonGet.Id)))
                
                .LessThan(100001)
                .WithMessage(ExceptionMessages.EXC013(nameof(JsonGet.Id),6));
        }
    }
}
