using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Companies.Commands.Create;
using GhostProject.App.Core.Business.Companies.Commands.Delete;
using GhostProject.App.Core.Business.Companies.Commands.Update;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Queries.GetAll;
using GhostProject.App.Core.Business.Companies.Queries.GetById;
using GhostProject.App.Core.Business.Companies.Queries.GetByName;
using GhostProject.App.Core.Business.Companies.Queries.GetByRecruiterId;
using GhostProject.App.Web.Controllers.Base;
using GhostProject.App.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhostProject.App.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns company by Id
        /// </summary>
        /// <response code="200">CompanyDto</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCompanyByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        
        
        /// <summary>
        /// Returns companies by recruiterId
        /// </summary>
        /// <response code="200">CompanyDto[]</response>
        [HttpGet("by-recruiter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetByRecruiterId([FromQuery]GetCompaniesByRecruiterIdQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Returns all companies
        /// </summary>
        /// <response code="200">Company list</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllCompaniesQuery(), cancellationToken);
            return Ok(response);
        }
        
        /// <summary>
        /// Returns company by name
        /// </summary>
        /// <response code="200">Company</response>
        [HttpGet("by-name")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetByName(string name, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCompanyByNameQuery(name), cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Update sample
        /// </summary>
        /// <param name="request">Sample</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <response code="200">No data</response> 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
        public async Task<IActionResult> Update(UpdateCompanyCommand request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        /// <summary>
        /// Create Company
        /// </summary>
        /// <param name="request">CreateCompanyCommand</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <response code="201">No data</response> 
        /// <response code="400">Non valid request</response>
        /// <response code="404">Sample not found</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
        public async Task<IActionResult> Create(CreateCompanyCommand request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        /// <summary>
        /// Delete Company
        /// </summary>
        /// <param name="id">company id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteCompanyCommand(id), cancellationToken);

            return Ok(response);
        }
    }
}
