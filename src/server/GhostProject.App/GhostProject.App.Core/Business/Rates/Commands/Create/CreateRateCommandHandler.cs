using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Business.Rates.Dto;
using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.Core.Business.Rates.Interfaces;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Common.Handlers;
using GhostProject.App.Core.Extensions;
using GhostProject.App.Core.Interfaces;
using GhostProject.App.Core.Models;

namespace GhostProject.App.Core.Business.Rates.Commands.Create;

public class CreateRateCommandHandler : HandlerBase<CreateRateCommand, RateDto>
{
    private readonly IEmailService _emailService;
    private readonly IEmailTemplateBuilder _emailTemplateBuilder;
    private readonly ICompanyRepository _companyRepository;
    private readonly IRateRepository _rateRepository;

    public CreateRateCommandHandler(
        IEmailService emailService,
        IEmailTemplateBuilder emailTemplateBuilder,
        ICompanyRepository companyRepository,
        IRateRepository rateRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _emailService = emailService;
        _emailTemplateBuilder = emailTemplateBuilder;
        _companyRepository = companyRepository;
        _rateRepository = rateRepository;
    }

    public override async Task<RateDto> Handle(CreateRateCommand request, CancellationToken cancellationToken)
    {
        var rate = Mapper.Map<Rate>(request);
        rate.ConfirmationId = Guid.NewGuid();
        rate.CreatedAt = DateTimeOffset.UtcNow;


        if (!string.IsNullOrEmpty(request.CompanyName) && !request.CompanyId.HasValue)
        {
            var company = await _companyRepository.FirstAsync(new SpecificationBuilder<Company>()
                    .FilterBy(x => x.CompanyNormalizedName == request.CompanyName.ToNormalizedCompanyName()),
                cancellationToken);
            if (company == null)
            {
                company = new Company
                {
                    Name = request.CompanyName,
                    CompanyNormalizedName = request.CompanyName.ToNormalizedCompanyName()
                };
                await _companyRepository.AddAsync(company, cancellationToken);
                rate.Company = company;
                
            }
        }

        await _rateRepository.AddAsync(rate, cancellationToken);
        await UnitOfWork.CommitAsync(cancellationToken);

        var body = _emailTemplateBuilder.CreateRateConfirmation(request.Email, rate.Id, rate.ConfirmationId);
        await _emailService.SendAsync(new EmailRequest
        {
            Addresses = new[] { rate.Email },
            Body = body,
            Subject = "Ghost Lookup Rate Verification",
        }, cancellationToken);

        return Mapper.Map<RateDto>(rate);
    }
}
