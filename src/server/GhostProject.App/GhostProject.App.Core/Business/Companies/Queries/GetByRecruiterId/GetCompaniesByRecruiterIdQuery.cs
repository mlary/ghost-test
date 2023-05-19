using System.ComponentModel.DataAnnotations;
using GhostProject.App.Core.Business.Companies.Dto;
using MediatR;

namespace GhostProject.App.Core.Business.Companies.Queries.GetByRecruiterId;

public class GetCompaniesByRecruiterIdQuery: IRequest<CompanyDto[]>
{
    [Required]
    public int RecruiterId { get; set; }
}
