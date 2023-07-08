using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Users.Commands.Authenticate;
using GhostProject.App.Core.Business.Users.Commands.ChangeStatus;
using GhostProject.App.Core.Business.Users.Commands.Create;
using GhostProject.App.Core.Business.Users.Commands.Delete;
using GhostProject.App.Core.Business.Users.Commands.Update;
using GhostProject.App.Core.Business.Users.Const;
using GhostProject.App.Core.Business.Users.Dto;
using GhostProject.App.Core.Business.Users.Queries.GetAll;
using GhostProject.App.Core.Business.Users.Queries.GetById;
using GhostProject.App.Core.Business.Users.Queries.GetCurrent;
using GhostProject.App.Core.Interfaces;
using GhostProject.App.Web.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhostProject.App.Web.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class UsersController : AppControllerBase
{
    private readonly IMediator _mediator;
    private readonly IGoogleRecaptchaService _recaptchaService;

    public UsersController(IMediator mediator, IGoogleRecaptchaService recaptchaService)
    {
        _mediator = mediator;
        _recaptchaService = recaptchaService;
    }

    /// <summary>
    /// verify recaptcha
    /// </summary>
    /// <response code="200">RecaptchaDto</response>
    [HttpPost("verify/{token}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecaptchaDto))]
    public async Task<IActionResult> Verify(string token, CancellationToken cancellationToken)
    {
        var response = await _recaptchaService.GetResultAsync(token, cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Authenticate user
    /// </summary>
    /// <response code="200">Token</response>
    [HttpPost("auth")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecaptchaDto))]
    public async Task<IActionResult> Authorize([FromBody]AuthenticateCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
    /// <summary>
    /// Create user
    /// </summary>
    /// <response code="200">User Dto</response>
    
    [HttpPost]
    [Authorize(Roles = UserRoles.Administrator)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecaptchaDto))]
    public async Task<IActionResult> Create([FromBody]CreateUserCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Update user
    /// </summary>
    /// <response code="200">User Dto</response>
    [HttpPut]
    [Authorize(Roles = UserRoles.Administrator)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    public async Task<IActionResult> Update([FromBody]UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Change user status
    /// </summary>
    /// <response code="200">User Dto</response>
    [HttpPatch("status/{id}/{blocked}")]
    [Authorize(Roles = UserRoles.Administrator)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ChangeStatus(int id, bool blocked, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ChangeUserStatusCommand(id, blocked), cancellationToken);
        return Ok();
    }
    
     
    /// <summary>
    /// Delete user
    /// </summary>
    /// <response code="200">User Dto</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = UserRoles.Administrator)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int id,  CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteUserCommand(id), cancellationToken);
        return Ok();
    }
    
    /// <summary>
    /// Get Current User
    /// </summary>
    /// <response code="200">User Dto</response>
    [HttpGet("current")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    public async Task<IActionResult> GetCurrent(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetCurrentUserQuery(UserIdentity), cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Get user by Id
    /// </summary>
    /// <response code="200">User Dto</response>
    [HttpGet("{id}")]
    [Authorize(Roles = UserRoles.Administrator)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        return Ok(response);
    }
    
     
    /// <summary>
    /// Get all users
    /// </summary>
    /// <response code="200">List of users</response>
    [HttpGet]
    [Authorize(Roles = UserRoles.Administrator)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto[]))]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
        return Ok(response);
    }
}
