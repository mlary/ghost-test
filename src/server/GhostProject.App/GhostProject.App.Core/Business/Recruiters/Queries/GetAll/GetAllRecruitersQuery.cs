using GhostProject.App.Core.Business.Recruiters.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Recruiters.Queries.GetAll;

public class GetAllRecruitersQuery : IRequest<RecruiterDto[]>
{
    public string ProfileId { get; set; }

    public string Name { get; set; }
}
