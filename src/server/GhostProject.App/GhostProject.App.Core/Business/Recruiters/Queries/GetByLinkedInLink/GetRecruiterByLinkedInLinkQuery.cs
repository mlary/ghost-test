using GhostProject.App.Core.Business.Recruiters.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Recruiters.Queries.GetByLinkedInLink;

public class GetRecruiterByLinkedInLinkQuery : IRequest<RecruiterDto>
{
    public string LinkedInUrl { get; }

    public GetRecruiterByLinkedInLinkQuery(string linkedInUrl)
    {
        LinkedInUrl = linkedInUrl;
    }
}
