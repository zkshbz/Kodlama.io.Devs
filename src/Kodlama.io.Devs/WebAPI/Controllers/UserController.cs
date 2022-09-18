using System.Xml.XPath;
using Application.Features.User.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] CreateUserCommand createUserCommand)
    {
        var result = await Mediator.Send(createUserCommand);
        return Created("",result);
    }
}