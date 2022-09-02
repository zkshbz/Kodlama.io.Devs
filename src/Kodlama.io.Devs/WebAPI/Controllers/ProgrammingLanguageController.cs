using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguageController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
    {
        var result = await Mediator.Send(createProgrammingLanguageCommand);
        return Created("", result);
    }
}
