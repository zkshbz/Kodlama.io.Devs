using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguage.Rules;

public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }
    
    public void ProgrammingLanguageNameCannotBeNull(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new BusinessException("Programming Language cannot be null");
    }

    public async Task ProgrammingLanguageCannotBeDuplicatedWhenInserted(string name)
    {
        var result = await _programmingLanguageRepository.GetListAsync(w => w.Name.Equals(name));

        if (result.Items.Any())
            throw new Exception("Programming Language exist.");
    }
}
