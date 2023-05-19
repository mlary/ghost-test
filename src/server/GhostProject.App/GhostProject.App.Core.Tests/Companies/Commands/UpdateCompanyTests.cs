using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using GhostProject.App.Core.Business.Companies.Commands.Update;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Tests.Common;
using GhostProject.App.Core.Tests.Data;
using Shouldly;
using Xunit;

namespace GhostProject.App.Core.Tests.Companies.Commands
{
    [Collection("DataCollection")]
    public class UpdateCompanyTests : CommandTestBase
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyTests(DataFixture dataFixture) : base(dataFixture)
        {
            _companyRepository =
                (ICompanyRepository)dataFixture.ServiceProvider.GetService(typeof(ICompanyRepository));
        }

        [Fact]
        public async Task UpdateCompanyCommandTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization() { ConfigureMembers = true });

            fixture.Inject(_companyRepository);
            fixture.Inject(Mapper);
            fixture.Inject(UnitOfWork);

            var commandHandler = fixture.Create<UpdateCompanyCommandHandler>();
            var response = await commandHandler.Handle(new UpdateCompanyCommand
            {
                Id = 1,
                Name = "test",
                LinkedInUrl = "http://linkedin.com",
            }, CancellationToken.None);

            response.ShouldBeOfType<CompanyDto>();
        }
    }
}
