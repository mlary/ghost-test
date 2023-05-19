using System.ComponentModel.DataAnnotations;

namespace GhostProject.App.Core.Business.Companies.Dto;

public class CompanyDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string CompanyNormalizedName { get; set; }

    public string LinkedInUrl { get; set; }
}
