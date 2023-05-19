using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using GhostProject.App.Core.Business.Rates.Commands.Create;
using GhostProject.App.Core.Business.Rates.Dto;
using GhostProject.App.Core.Business.Rates.Interfaces;
using GhostProject.App.Core.Interfaces;
using GhostProject.App.Core.Models;
using GhostProject.App.Core.Tests.Common;
using GhostProject.App.Core.Tests.Data;
using Moq;
using Shouldly;
using Xunit;

namespace GhostProject.App.Core.Tests.Rates.Commands
{
    [Collection("DataCollection")]
    public class CreateRateTests : CommandTestBase
    {
        private readonly IRateRepository _rateRepository;

        public CreateRateTests(DataFixture dataFixture) : base(dataFixture)
        {
            _rateRepository =
                (IRateRepository)dataFixture.ServiceProvider.GetService(typeof(IRateRepository));
        }

        [Fact]
        public async Task CreateOrUpdateRecruiterTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization() { ConfigureMembers = true });
            fixture.Inject(UnitOfWork);
            fixture.Inject(Mapper);
            fixture.Inject(_rateRepository);

            var emailService = fixture.Freeze<Mock<IEmailService>>();
            var emailTemplateService = fixture.Freeze<Mock<IEmailTemplateBuilder>>();

            emailService.Setup(x => x.SendAsync(It.IsAny<EmailRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            emailTemplateService.Setup(x => x.CreateRateConfirmation(It.IsAny<string>(), 
                    It.IsAny<int>(),
                    It.IsAny<Guid>()))
                .Returns("test email body");

            var commandHandler = fixture.Create<CreateRateCommandHandler>();


            var response = await commandHandler.Handle(new CreateRateCommand
            {
                Comment = "test notes",
                Email = "test@gmail.com",
                CancelledInterview = false,
                QuestionsRate = 1,
                RecruiterId = 1,
                RecruitingType = 1,
                InterviewerInterestRate = 1,
                InterviewerListeningRate = 1,
                LateInMinutes = 10,
            }, CancellationToken.None);

            response.ShouldBeOfType<RateDto>();
        }
    }
}
