using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Business.Companies.Queries.GetAll;
using GhostProject.App.Core.Business.Companies.Queries.GetById;
using GhostProject.App.Core.Tests.Common;
using GhostProject.App.Core.Tests.Data;
using Moq;
using Shouldly;
using Xunit;

namespace GhostProject.App.Core.Tests.Companies.Queries
{
    [Collection("DataCollection")]
    public class GetCompaniesTests : CommandTestBase
    {
        public GetCompaniesTests(DataFixture dataFixture) : base(dataFixture)
        {
        }

        [Fact]
        public async Task GetAllCompaniesTest()
        {
            var sampleData = new[]
            {
                new Company
                {
                    Id = 1,
                    Name = "test",
                    LinkedInUrl = "https://linkedin.com",
                }
            };
            var expectedResults = Mapper.Map<CompanyDto[]>(sampleData);

            var fixture = new Fixture().Customize(new AutoMoqCustomization() { ConfigureMembers = true });
            var companyRepository = fixture.Freeze<Mock<ICompanyRepository>>();
            companyRepository.Setup(expression: x =>
                    x.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<bool>()))
                .ReturnsAsync(sampleData);
            fixture.Inject(Mapper);

            var queryHandler = fixture.Create<GetAllCompaniesQueryHandler>();

            var response = await queryHandler.Handle(new GetAllCompaniesQuery(), CancellationToken.None);

            response.ShouldBeEquivalentTo(expectedResults);
        }

        [Fact]
        public async Task GetCompanyById()
        {
            var company = new Company()
            {
                Id = 1,
                Name = "test",
                LinkedInUrl = "https://linkedin.com",
            };
            var expectedResult = Mapper.Map<CompanyDto>(company);

            var fixture = new Fixture().Customize(new AutoMoqCustomization() { ConfigureMembers = true });
            var companyRepository = fixture.Freeze<Mock<ICompanyRepository>>();
            companyRepository.Setup(expression: x =>
                    x.FindByIdAsync(It.IsAny<int>(),
                        It.IsAny<CancellationToken>(), It.IsAny<bool>()))
                .ReturnsAsync(company);
            fixture.Inject(Mapper);

            var queryHandler = fixture.Create<GetCompanyByIdQueryHandler>();

            var response = await queryHandler.Handle(new GetCompanyByIdQuery(1), CancellationToken.None);

            response.ShouldBeEquivalentTo(expectedResult);
        }
    }
}
