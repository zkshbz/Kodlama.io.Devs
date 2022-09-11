using Application.Features.ProgrammingLanguageTechnology.Commands.CreateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnology.Commands.DeleteProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnology.Commands.UpdateProgrammingLanguguageTechnology;
using Application.Features.ProgrammingLanguageTechnology.Queries.GetByIdProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnology.Queries.GetListProgrammingLanguageTechnology;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguageTechnologyController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateProgrammingLanguageTechnologyCommand createProgrammingLanguageTechnologyCommand)
    {
        var result = await Mediator.Send(createProgrammingLanguageTechnologyCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteProgrammingLanguageTechnologyCommand deleteProgrammingLanguageTechnologyCommand)
    {
        var result = await Mediator.Send(deleteProgrammingLanguageTechnologyCommand);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        [FromBody] UpdateProgrammingLanguageTechnologyCommand updateProgrammingLanguageTechnologyCommand)
    {
        var result = await Mediator.Send(updateProgrammingLanguageTechnologyCommand);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromRoute] GetByIdProgrammingLanguageTechnologyQuery getByIdProgrammingLanguageTechnologyQuery)
    {
        var result = await Mediator.Send(getByIdProgrammingLanguageTechnologyQuery);
        return Ok(result);
    }
    
    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody] Dynamic dynamic)
    {
        var getListProgrammingLanguageTechnologyQuery = new GetListProgrammingLanguageTechnologyQuery
        {
            Dynamic = dynamic,
            PageRequest = pageRequest
        };
        
        var result = await Mediator.Send(getListProgrammingLanguageTechnologyQuery);
        
        return Ok(result);
    }
}
