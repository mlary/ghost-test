using System.Collections.Generic;
using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.Core.Common;

namespace GhostProject.App.Core.Business.Companies.Entities;

public class Company : BaseEntity<int>
{
    public string Name { get; set; }

    public string CompanyNormalizedName { get; set; }

    public string LinkedInUrl { get; set; }

    public virtual ICollection<Recruiter> Recruiters { get; set; }

    public virtual ICollection<Rate> Rates { get; set; }
}
