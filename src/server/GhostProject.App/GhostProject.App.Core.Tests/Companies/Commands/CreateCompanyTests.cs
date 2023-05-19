using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using GhostProject.App.Core.Business.Companies.Commands.Create;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Tests.Common;
using GhostProject.App.Core.Tests.Data;
using Shouldly;
using Xunit;

namespace GhostProject.App.Core.Tests.Companies.Commands
{
    [Collection("DataCollection")]
    public class CreateCompanyTests : CommandTestBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyTests(DataFixture dataFixture) : base(dataFixture)
        {
            _companyRepository =
                (ICompanyRepository) dataFixture.ServiceProvider.GetService(typeof(ICompanyRepository));
        }

        [Fact]
        public async Task CreateCompanyCommandTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization() {ConfigureMembers = true});
            fixture.Inject(UnitOfWork);
            fixture.Inject(Mapper);
            fixture.Inject(_companyRepository);

            var commandHandler = fixture.Create<CreateCompanyCommandHandler>();


            var response = await commandHandler.Handle(new CreateCompanyCommand
            {
                Name = "test",
                LinkedInUrl = "https://linkedin.com/test1"
            }, CancellationToken.None);

            response.ShouldBeOfType<CompanyDto>();
        }
    }
}
