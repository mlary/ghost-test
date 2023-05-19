using System.ComponentModel.DataAnnotations;
using GhostProject.App.Core.Business.Companies.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Companies.Commands.Update;

public class UpdateCompanyCommand: IRequest<CompanyDto>
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    public string LinkedInUrl { get; set; }
}
