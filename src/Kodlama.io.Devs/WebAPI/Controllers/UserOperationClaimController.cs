using Application.Features.UserOperationClaim.Commands.CreateUserOperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserOperationClaimController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromQuery] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        var result = await Mediator.Send(createUserOperationClaimCommand);
        return Created("", result);
    }
}