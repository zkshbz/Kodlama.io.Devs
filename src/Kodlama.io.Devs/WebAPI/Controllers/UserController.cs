using System.Xml.XPath;
using Application.Features.User.Commands.CreateUser;
using Application.Features.User.Queries.UserLoginByJWT;
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
    
    [HttpGet("{Email}/{Password}")]
    public async Task<IActionResult> SignIn([FromRoute] UserLoginByJWTQuery userLoginByJwtQuery)
    {
        var result = await Mediator.Send(userLoginByJwtQuery);
        return Ok(result);
    }
}