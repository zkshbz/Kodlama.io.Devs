using FluentValidation;

namespace Application.Features.ProgrammingLanguageTechnology.Commands.UpdateProgrammingLanguguageTechnology;

public class
    UpdateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<UpdateProgrammingLanguageTechnologyCommand>
{
    public UpdateProgrammingLanguageTechnologyCommandValidator()
    {
        RuleFor(f => f.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(20)
            .When(w => w.ProgrammingLanguageId < 0);

        RuleFor(f => f.ProgrammingLanguageId)
            .GreaterThanOrEqualTo(1)
            .When(w => string.IsNullOrEmpty(w.Name));
    }
}
