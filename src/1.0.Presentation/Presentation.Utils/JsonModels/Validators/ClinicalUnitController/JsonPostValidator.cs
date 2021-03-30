using FluentValidation;
using Presentation.Utils.Messages;
using Presentation.Utils.JsonModels.Models.ClinicalUnitController;

namespace Presentation.Utils.JsonModels.Validators.ClinicalUnitController
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

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(JsonPost.CompanyName)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(JsonPost.CompanyName)))

                .MinimumLength(3)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(JsonPost.CompanyName),3))

                .MaximumLength(180)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(JsonPost.CompanyName),180));

            RuleFor(x => x.TaxNumber)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(JsonPost.TaxNumber)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(JsonPost.TaxNumber)));

            When(x => x.TaxNumber != null && x.TaxNumber.Length != 11 && x.TaxNumber.Length != 14, () => {
                RuleFor(x => x.TaxNumber)
                    .Empty()
                    .WithMessage(string.Format(ExceptionMessages.EXC015(),nameof(JsonPost.TaxNumber)));
            });

            When(x => x.TaxNumber != null && x.TaxNumber.Length == 11, () => {
                RuleFor(x => x.TaxNumber)
                    .Must(x => Utils.IsValidCPF(x))
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(JsonPost.TaxNumber)));
            });

            When(x => x.TaxNumber != null && x.TaxNumber.Length == 14, () => {
                RuleFor(x => x.TaxNumber)
                    .Must(x => Utils.IsValidCNPJ(x))
                    .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(JsonPost.TaxNumber)));
            });
        }
    }
}
