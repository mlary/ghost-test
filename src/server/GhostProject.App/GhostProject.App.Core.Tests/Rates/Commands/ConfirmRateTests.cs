using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using GhostProject.App.Core.Business.Rates.Commands.Confirm;
using GhostProject.App.Core.Business.Rates.Interfaces;
using GhostProject.App.Core.Tests.Common;
using GhostProject.App.Core.Tests.Data;
using MediatR;
using Shouldly;
using Xunit;

namespace GhostProject.App.Core.Tests.Rates.Commands
{
    [Collection("DataCollection")]
    public class ConfirmRateTests : CommandTestBase

    {
        private readonly DataFixture _dataFixture;
        private readonly IRateRepository _rateRepository;

        public ConfirmRateTests(DataFixture dataFixture) : base(dataFixture)
        {
            _dataFixture = dataFixture;
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
            
            
            var commandHandler = fixture.Create<ConfirmRateCommandHandler>();


            var response = await commandHandler.Handle(new ConfirmRateCommand(_dataFixture.TestConfirmationId), CancellationToken.None);

            response.ShouldBeOfType<Unit>();
        }
    }
}
