using FluentValidation;
using Presentation.Utils.Messages;
using Presentation.Utils.JsonModels.Models.ScheduleController;

namespace Presentation.Utils.JsonModels.Validators.ScheduleController
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

            RuleFor(x => x.ScheduleDate)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(JsonPost.ScheduleDate)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(JsonPost.ScheduleDate)));

            RuleFor(x => x.PatientId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(JsonPost.PatientId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(JsonPost.PatientId)))
                
                .LessThan(100001)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(JsonPost.PatientId),6));
            
            RuleFor(x => x.ClinicalUnitId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(JsonPost.ClinicalUnitId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(JsonPost.ClinicalUnitId)))
                
                .LessThan(100001)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(JsonPost.ClinicalUnitId),6));
        }
    }
}
