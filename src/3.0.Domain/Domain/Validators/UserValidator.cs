using FluentValidation;
using Domain.Entities;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazia.")

                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(180)
                .WithMessage("O nome deve ter no mínimo 80 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail não pode ser vazia.")

                .NotNull()
                .WithMessage("O e-mail não pode ser nulo.")

                .MinimumLength(6)
                .WithMessage("O e-mail deve ter no mínimo 6 caracteres.")

                .MaximumLength(180)
                .WithMessage("O e-mail deve ter no mínimo 180 caracteres.")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O e-mail informado não é válido.");
            
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia.")

                .NotNull()
                .WithMessage("A senha não pode ser nulo.")

                .MinimumLength(10)
                .WithMessage("A senha deve ter no mínimo  caracteres.")

                .MaximumLength(180)
                .WithMessage("A senha deve ter no mínimo 30 caracteres.");
        }
    }
}
