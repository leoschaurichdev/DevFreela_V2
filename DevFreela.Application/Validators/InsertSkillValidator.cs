using DevFreela.Application.Commands.SkillCommands.InsertSkill;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class InsertSkillValidator : AbstractValidator<InsertSkillCommand>
    {
        public InsertSkillValidator()
        {
            RuleFor(x => x.Description)
                .MinimumLength(5)
                    .WithMessage("Deve ter no mínimo 5 caracteres.")
                .MaximumLength(150)
                    .WithMessage("Máximo 150 caracteres.");
        }
    }
}
