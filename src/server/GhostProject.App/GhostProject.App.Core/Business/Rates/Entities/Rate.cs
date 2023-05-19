using System;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.Core.Common;

namespace GhostProject.App.Core.Business.Rates.Entities;

public class Rate : BaseEntity<int>
{
    public string Email { get; set; }

    public int RecruitingType { get; set; }

    public int? CompanyId { get; set; }

    public int RecruiterId { get; set; }

    public int InterviewRound { get; set; }
    
    public int VisitedLinkedInProfile { get; set; }
    
    public int PositionSeniorityLevel { get; set; }
    public int LateInMinutes { get; set; }

    public bool CancelledInterview { get; set; }

    public int InterviewerListeningRate { get; set; }

    public int InterviewerInterestRate { get; set; }

    public string Comment { get; set; }
    
    public string CompanyName { get; set; }

    public int QuestionsRate { get; set; }
    
    public int CommonRating { get; set; }
    
    public bool IsConfirmed { get; set; }
    
    public Guid ConfirmationId { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }

    public virtual Recruiter Recruiter { get; set; }

    public virtual Company Company { get; set; }
}
