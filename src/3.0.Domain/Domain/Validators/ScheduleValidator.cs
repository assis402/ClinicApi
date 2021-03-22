using FluentValidation;
using Domain.Entities;
using Presentation.Utils.Messages;

namespace Domain.Validators
{
    public class ScheduleValidator : AbstractValidator<Schedule>
    {
        public ScheduleValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC001(),nameof(Schedule)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC002(),nameof(Schedule)));
        }
    }
}