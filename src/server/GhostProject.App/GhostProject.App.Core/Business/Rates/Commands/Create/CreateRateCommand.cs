using System.ComponentModel.DataAnnotations;
using GhostProject.App.Core.Business.Rates.Dto;
using GhostProject.App.Core.Business.Rates.Primitives;
using MediatR;

namespace GhostProject.App.Core.Business.Rates.Commands.Create;

public class CreateRateCommand : IRequest<RateDto>
{
    [Required]
    public string Email { get; set; }

    [Required]
    public int RecruitingType { get; set; }

    public int? CompanyId { get; set; }
    
    public string CompanyName { get; set; }

    [Required]
    public int RecruiterId { get; set; }

    [Required]
    public int CommonRating { get; set; }

    [Required]
    public int InterviewRound { get; set; }
    
    [Required]
    public PositionSeniorityLevels PositionSeniorityLevel { get; set; }

    [Required]
    public int LateInMinutes { get; set; }

    [Required]
    public bool CancelledInterview { get; set; }

    [Required]
    public int InterviewerListeningRate { get; set; }

    [Required]
    public int InterviewerInterestRate { get; set; }
    
    [Required]
    public string Comment { get; set; }

    [Required]
    public AnswerTypes VisitedLinkedInProfile { get; set; }

    [Required]
    public int QuestionsRate { get; set; }
}
