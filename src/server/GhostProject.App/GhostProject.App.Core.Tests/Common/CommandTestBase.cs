using AutoMapper;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Tests.Data;
using MediatR;

namespace GhostProject.App.Core.Tests.Common
{
    public abstract class CommandTestBase
    {
        protected IUnitOfWork UnitOfWork { get; }
        
        protected IMapper Mapper { get; }
        
        protected IMediator Mediator { get; }
        
        protected CommandTestBase(DataFixture dataFixture)
        {
            Mediator = dataFixture.Mediator;
            Mapper = dataFixture.Mapper;
            UnitOfWork = dataFixture.UnitOfWork;
        }
    }
}
