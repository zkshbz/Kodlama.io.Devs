using FluentValidation;

namespace Application.Features.ProgrammingLanguageTechnology.Queries.GetByIdProgrammingLanguageTechnology;

public class
    GetByIdProgrammingLanguageTechnologyQueryValidator : AbstractValidator<GetByIdProgrammingLanguageTechnologyQuery>
{
    public GetByIdProgrammingLanguageTechnologyQueryValidator()
    {
        RuleFor(f => f.Id).GreaterThanOrEqualTo(1);
    }
}