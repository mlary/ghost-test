using System.ComponentModel.DataAnnotations;
using GhostProject.App.Core.Business.Recruiters.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Recruiters.Commands.Create;

public class CreateOrUpdateRequiterCommand: IRequest<RecruiterDto>
{
    [Required]
    public string LinkedInProfileId { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string CompanyName { get; set; }

    public int? CompanyId { get; set; }
}
