using Application.Features.ProgrammingLanguageTechnology.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguageTechnology.Models;

public class ProgrammingLanguageTechnologyListModel : BasePageableModel
{
    public IList<ProgrammingLanguageTechnologyListDto> Items { get; set; }
}
