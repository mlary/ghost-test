using AutoMapper;
using GhostProject.App.DataAccess;
using GhostProject.App.Tests.Common;
using GhostProject.App.Web.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.Core.Business.Recruiters.Entities;
using GhostProject.App.Core.Business.Recruiters.Interfaces;
using GhostProject.App.Core.Common.Abstractions.DataAccess;

namespace GhostProject.App.Core.Tests.Data
{
    public class DataFixture
    {
        public DataFixture()
        {
            Configuration = MockFactory.CreateConfigurationMock();
            ServiceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("InsightsCommonTemplate-Test"); })
                .AddMemoryCache()
                .RegisterServices(Configuration)
                .RegisterValidators()
                .BuildServiceProvider();
            UnitOfWork = (IUnitOfWork)ServiceProvider.GetService(typeof(IUnitOfWork));
            Mapper = MockFactory.CreateMapperMock();
            Mediator = (IMediator)ServiceProvider.GetService(typeof(IMediator));
            TestConfirmationId = Guid.NewGuid();
            GenerateData();
        }

        public IServiceProvider ServiceProvider { get; }

        public IConfiguration Configuration { get; }

        public IUnitOfWork UnitOfWork { get; }

        public IMapper Mapper { get; }

        public IMediator Mediator { get; }

        public Guid TestConfirmationId { get; }

        private void GenerateData()
        {
            var repository =
                (IRecruiterRepository)ServiceProvider.GetService(typeof(IRecruiterRepository));
            repository.Add(new Recruiter
            {
                Surname = "test",
                FirstName = "test",
                Company = new Company
                {
                    Name = "test",
                    LinkedInUrl = "https://linkedin.com",
                },
                CreatedAt = DateTimeOffset.UtcNow,
                ModifiedAt = DateTimeOffset.UtcNow,
                LinkedInUrl = "https://linkedin.com",
                Rates = new List<Rate>
                {
                    new Rate
                    {
                        Comment = "test notes",
                        Email = "test@gmail.com",
                        ConfirmationId = TestConfirmationId,
                        CreatedAt = DateTimeOffset.UtcNow,
                        CancelledInterview = true,
                        RecruitingType = 1,
                        InterviewerInterestRate = 1,
                        InterviewerListeningRate = 1,
                        QuestionsRate = 1,
                        IsConfirmed = false,
                        LateInMinutes = 10,
                    }
                }
            });
            UnitOfWork.Commit();
        }
    }
}
