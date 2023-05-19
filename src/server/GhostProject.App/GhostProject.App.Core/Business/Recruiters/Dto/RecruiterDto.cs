using System;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Common;

namespace GhostProject.App.Core.Business.Recruiters.Dto;

public class RecruiterDto : BaseEntityDto<int>
{
    public string Surname { get; set; }

    public string FirstName { get; set; }

    public string LinkedInUrl { get; set; }

    public int? CompanyId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }

    public virtual Company Company { get; set; }
}
