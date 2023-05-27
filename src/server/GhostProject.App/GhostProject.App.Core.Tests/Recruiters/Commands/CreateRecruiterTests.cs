using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using GhostProject.App.Core.Business.Recruiters.Commands.Create;
using GhostProject.App.Core.Business.Recruiters.Dto;
using GhostProject.App.Core.Business.Recruiters.Interfaces;
using GhostProject.App.Core.Tests.Common;
using GhostProject.App.Core.Tests.Data;
using Shouldly;
using Xunit;

namespace GhostProject.App.Core.Tests.Recruiters.Commands
{
    [Collection("DataCollection")]
    public class CreateRecruiterTests : CommandTestBase
    {
        private readonly IRecruiterRepository _recruiterRepository;

        public CreateRecruiterTests(DataFixture dataFixture) : base(dataFixture)
        {
            _recruiterRepository =
                (IRecruiterRepository)dataFixture.ServiceProvider.GetService(typeof(IRecruiterRepository));
        }

        [Fact]
        public async Task CreateOrUpdateRecruiterTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization() { ConfigureMembers = true });
            fixture.Inject(UnitOfWork);
            fixture.Inject(Mapper);
            fixture.Inject(_recruiterRepository);

            var commandHandler = fixture.Create<CreateOrUpdateRequiterCommandHandler>();


            var response = await commandHandler.Handle(new CreateOrUpdateRequiterCommand
            {
                Surname = "test",
                FirstName = "test",
                LinkedInProfileId = "michael-larin-7b008673",
            }, CancellationToken.None);

            response.ShouldBeOfType<RecruiterDto>();
        }
    }
}
