using DevFreela.Application.Commands.UserCommands.InsertUser;
using FluentValidation;


namespace DevFreela.Application.Validators
{
    public class InsertUserValidator : AbstractValidator<InsertUserCommand>
    {
        public InsertUserValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email inválido.");

            RuleFor(u => u.BirthDate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                .WithMessage("Deve ser maior de idade.");

        }
    }
}
