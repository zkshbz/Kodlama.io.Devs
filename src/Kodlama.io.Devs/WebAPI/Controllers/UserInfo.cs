using System.Diagnostics.CodeAnalysis;
using Application.Features.UserInfo.Commands.CreateUserInfoGitHubLink;
using Application.Features.UserInfo.Commands.DeleteUserInfoGitHubLink;
using Application.Features.UserInfo.Commands.UpdateUserInfoGitHubLink;
using Application.Features.UserInfo.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserInfo : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserInfoGitHubLinkCommand createUserInfoGitHubLinkCommand)
    {
        var result = await Mediator.Send(createUserInfoGitHubLinkCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] UpdateUserInfoGitHubLinkCommand updateUserInfoGitHubLinkCommand)
    {
        var result = await Mediator.Send(updateUserInfoGitHubLinkCommand);
        return Ok(result);
    }
    
    [HttpDelete("{UserId}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteUserInfoGitHubLinkCommand deleteUserInfoGitHubLinkCommand)
    {
        var result = await Mediator.Send(deleteUserInfoGitHubLinkCommand);
        return Ok(result);
    }
}