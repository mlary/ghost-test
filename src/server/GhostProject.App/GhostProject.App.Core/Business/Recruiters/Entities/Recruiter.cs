using System;
using System.Collections.Generic;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.Core.Common;

namespace GhostProject.App.Core.Business.Recruiters.Entities;

public class Recruiter : BaseEntity<int>
{
    public string Surname { get; set; }

    public string FirstName { get; set; }

    public string LinkedInUrl { get; set; }

    public string LinkedInProfileId { get; set; }

    public string NormalizedRecruiterName { get; set; }

    public int? CompanyId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }

    public virtual Company Company { get; set; }

    public virtual ICollection<Rate> Rates { get; set; }
}
