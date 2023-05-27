using System;
using System.ComponentModel.DataAnnotations;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Common;

namespace GhostProject.App.Core.Business.Recruiters.Dto;

public class RecruiterDto : BaseEntityDto<int>
{
    [Required]
    public string Surname { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LinkedInUrl { get; set; }
    
    [Required]
    public string LinkedInProfileId { get; set; }

    public int? CompanyId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }

    public CompanyDto Company { get; set; }
}
