using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Recruiters.Dto;
using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.Core.Business.Recruiters.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;

namespace GhostProject.App.Core.Business.Recruiters.Commands.Create;

public class CreateOrUpdateRequiterCommandHandler : HandlerBase<CreateOrUpdateRequiterCommand, RecruiterDto>
{
    private readonly IRecruiterRepository _recruiterRepository;

    public CreateOrUpdateRequiterCommandHandler(
        IRecruiterRepository recruiterRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _recruiterRepository = recruiterRepository;
    }

    public override async Task<RecruiterDto> Handle(CreateOrUpdateRequiterCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _recruiterRepository.GetByProfileIdUrlAsync(request.LinkedInProfileId, cancellationToken);
        if (result != null)
        {
            Mapper.Map(request, result);
        }
        else
        {
            result = Mapper.Map<Recruiter>(request);
            result.CreatedAt = DateTimeOffset.UtcNow;
            await _recruiterRepository.AddAsync(result, cancellationToken);
        }

        await UnitOfWork.CommitAsync(cancellationToken);
        return Mapper.Map<RecruiterDto>(result);
    }
}
