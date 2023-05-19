using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Recruiters.Dto;
using GhostProject.App.Core.Business.Recruiters.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Exceptions;

namespace GhostProject.App.Core.Business.Recruiters.Queries.GetById;

public class GetRecruiterByIdQueryHandler : HandlerBase<GetRecruiterByIdQuery, RecruiterDto>
{
    private readonly IRecruiterRepository _recruiterRepository;

    public GetRecruiterByIdQueryHandler(
        IRecruiterRepository recruiterRepository,
        IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _recruiterRepository = recruiterRepository;
    }

    public override async Task<RecruiterDto> Handle(GetRecruiterByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _recruiterRepository.FindByIdAsync(request.Id, cancellationToken);
        if (result == null)
        {
            throw new NotFoundException($"Recruiter with id {request.Id} was not found");
        }

        return Mapper.Map<RecruiterDto>(result);
    }
}
