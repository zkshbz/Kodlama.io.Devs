using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProgrammingLanguageTechnology : Entity
{
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
    
    public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
    
    public ProgrammingLanguageTechnology() { }

    public ProgrammingLanguageTechnology(int id,string name, int programmingLanguageId)
    {
        Id = id;
        Name = name;
        ProgrammingLanguageId = programmingLanguageId;
    }
}
