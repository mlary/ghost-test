using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Recruiters.Commands.Create;
using GhostProject.App.Core.Business.Recruiters.Dto;
using GhostProject.App.Core.Business.Recruiters.Queries.GetAll;
using GhostProject.App.Core.Business.Recruiters.Queries.GetById;
using GhostProject.App.Core.Business.Recruiters.Queries.GetByLinkedInLink;
using GhostProject.App.Web.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhostProject.App.Web.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class RecruitersController : AppControllerBase
{
    private readonly IMediator _mediator;

    public RecruitersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecruiterDto[]))]
    public async Task<IActionResult> GetAll([FromQuery] GetAllRecruitersQuery query,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecruiterDto))]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetRecruiterByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpGet("linkedin-profile")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecruiterDto))]
    public async Task<IActionResult> GetByProfileId([FromQuery] string linkedIn, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetRecruiterByLinkedInLinkQuery(linkedIn), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecruiterDto))]
    public async Task<IActionResult> CreateOrUpdate([FromBody] CreateOrUpdateRequiterCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}
