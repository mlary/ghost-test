using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Users.Dto;
using GhostProject.App.Core.Interfaces;
using GhostProject.App.Web.Controllers.Base;
using MediatR;
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
    /// <response code="200">RateDto</response>
    [HttpPost("verify/{token}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecaptchaDto))]
    public async Task<IActionResult> Verify(string token, CancellationToken cancellationToken)
    {
        var response = await _recaptchaService.GetResultAsync(token, cancellationToken);
        return Ok(response);
    }
}
