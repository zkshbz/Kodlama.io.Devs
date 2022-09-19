using Application.Features.OperationClaim.Commands.CreateOperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationClaimController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        var result = await Mediator.Send(createOperationClaimCommand);
        return Created("", result);
    }
}