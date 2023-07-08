using System;
using System.ComponentModel.DataAnnotations;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Rates.Primitives;
using GhostProject.App.Core.Business.Recruiters.Dto;
using GhostProject.App.Core.Common;

namespace GhostProject.App.Core.Business.Rates.Dto;

public class RateDto: BaseEntityDto<int>
{
    [Required]
    public string Email { get; set; }

    [Required]
    public int RecruitingType { get; set; }

    public int? CompanyId { get; set; }

    [Required]
    public int RecruiterId { get; set; }

    [Required]
    public int LateInMinutes { get; set; }

    public string CompanyName { get; set; }
    
    [Required]
    public int CommonRating { get; set; }

    [Required]
    public int InterviewRound { get; set; }
    
    [Required]
    public PositionSeniorityLevels PositionSeniorityLevel { get; set; }
    
    [Required]
    public AnswerTypes VisitedLinkedInProfile { get; set; }

    [Required]
    public bool CancelledInterview { get; set; }

    [Required]
    public int InterviewerListeningRate { get; set; }

    [Required]
    public int InterviewerInterestRate { get; set; }
    
    [Required]
    public string Comment { get; set; }

    [Required]
    public int QuestionsRate { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    [Required]
    public bool IsConfirmed { get; set; }
    
    public RecruiterDto Recruiter { get; set; }
    
    public CompanyDto Company { get; set; }

  
}
