using System.ComponentModel.DataAnnotations;

namespace GhostProject.App.Core.Business.Rates.Primitives
{
    public enum RecruitingTypes
    {
        [Display(Name = "Initial Recruiter")]
        InitialRecruiter = 1,
        [Display(Name = "Interviewer")]
        Interviewer = 2
    }
}
