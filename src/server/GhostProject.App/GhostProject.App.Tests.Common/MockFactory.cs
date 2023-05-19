using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Business.Companies.Mappings;
using GhostProject.App.Core.Business.Rates.Mappings;
using GhostProject.App.Core.Business.Recruiters.Mappings;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using Microsoft.Extensions.Configuration;
using Moq;

namespace GhostProject.App.Tests.Common
{
    public static class MockFactory
    {
        public static IConfigurationRoot CreateConfigurationMock() => new ConfigurationBuilder()
            .Build();

        public static IUnitOfWork CreateUnitOfWorkMock()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);

            return mockRepository
                .Of<IUnitOfWork>()
                .First(unitOfWork => unitOfWork.CommitAsync(CancellationToken.None) == Task.FromResult(""));
        }

        public static IMapper CreateMapperMock()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<CompanyMappingProfile>();
                mc.AddProfile<RateMappingProfile>();
                mc.AddProfile<RecruiterMappingProfile>();
            });

            return mapperConfig.CreateMapper();
        }
    }
}
