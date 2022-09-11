using System.Data;
using Application.Features.ProgrammingLanguageTechnology.Dtos;
using FluentValidation;

namespace Application.Features.ProgrammingLanguageTechnology.Commands.CreateProgrammingLanguageTechnology;

public class CreateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<CreatedProgrammingLanguageTechnologyCommandDto>
{
    public CreateProgrammingLanguageTechnologyCommandValidator()
    {
        RuleFor(r => r.Name).NotNull();
        RuleFor(r => r.Name).NotEmpty();
        RuleFor(r => r.Name).MinimumLength(2);
        RuleFor(r => r.Name).MaximumLength(20);

        RuleFor(r => r.ProgrammingLanguageId).NotNull();
        RuleFor(r => r.ProgrammingLanguageId).NotEmpty();
        RuleFor(r => r.ProgrammingLanguageId).GreaterThanOrEqualTo(1);
    }
}