using System;
using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Rates.Commands.Confirm;
using GhostProject.App.Core.Business.Rates.Commands.Create;
using GhostProject.App.Core.Business.Rates.Dto;
using GhostProject.App.Core.Business.Rates.Queries.GetById;
using GhostProject.App.Web.Controllers.Base;
using GhostProject.App.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhostProject.App.Web.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class RatesController : AppControllerBase
{
    private readonly IMediator _mediator;

    public RatesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create rate
    /// </summary>
    /// <response code="200">RateDto</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Create([FromBody]CreateRateCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Confirm rate
    /// </summary>
    [HttpPatch("{confirmationId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Confirm(Guid confirmationId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new ConfirmRateCommand(confirmationId), cancellationToken);
        return Ok(response);
    }
    
    /// <summary>
    /// Get rate
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RateDto))]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetRateByIdQuery(id), cancellationToken);
        return Ok(response);
    }
}
