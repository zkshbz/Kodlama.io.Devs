using Application.Features.ProgrammingLanguage.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.ProgrammingLanguageTechnology.Rules;

public class ProgrammingLanguageTechnologyBusinessRules
{
    private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
    private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

    public ProgrammingLanguageTechnologyBusinessRules(
        IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
    {
        _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
        _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
    }

    public async Task NameAlreadyExistBySpecificProgrammingLanguageId(int programmingLanguageId, string name)
    {
        var result = await _programmingLanguageTechnologyRepository
            .GetAsync(w => w.ProgrammingLanguageId == programmingLanguageId &&
                           w.Name.Equals(name));

        if (result != null)
            throw new BusinessException(
                $"Name already exist for this programming language id: {programmingLanguageId}");
    }

    public async Task HasProgrammingLanguageWithThisIs(int programmingLanguageId)
    {
        await _programmingLanguageBusinessRules.ProgrammingLanguageShouldBeExist(programmingLanguageId);
    }

    public async Task HasProgrammingLanguageTechnologyWithThisId(int programmingLanguageTechnologyId)
    {
        var result = await
            _programmingLanguageTechnologyRepository.GetAsync(w => w.Id == programmingLanguageTechnologyId);

        if (result == null)
            throw new BusinessException(
                $"There is not programming language technology with this id {programmingLanguageTechnologyId}");
    }
}