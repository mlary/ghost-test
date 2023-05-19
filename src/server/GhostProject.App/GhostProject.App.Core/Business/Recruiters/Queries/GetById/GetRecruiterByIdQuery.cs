using GhostProject.App.Core.Business.Recruiters.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Recruiters.Queries.GetById;

public class GetRecruiterByIdQuery : IRequest<RecruiterDto>
{
    public int Id { get; }

    public GetRecruiterByIdQuery(int id)
    {
        Id = id;
    }
}
