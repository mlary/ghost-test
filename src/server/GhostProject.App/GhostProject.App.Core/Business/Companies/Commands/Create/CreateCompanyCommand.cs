using System.ComponentModel.DataAnnotations;
using GhostProject.App.Core.Business.Companies.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Companies.Commands.Create;

public class CreateCompanyCommand: IRequest<CompanyDto>
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string LinkedInUrl { get; set; }
}
