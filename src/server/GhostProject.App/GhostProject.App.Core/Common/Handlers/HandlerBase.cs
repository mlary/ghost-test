using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using MediatR;

namespace GhostProject.App.Core.Common.Handlers
{
    public abstract class HandlerBase<TQ, TM> : IRequestHandler<TQ, TM>
        where TQ : IRequest<TM>
    {
        protected IMapper Mapper { get; }
        
        protected IUnitOfWork UnitOfWork { get; }

        protected HandlerBase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            UnitOfWork = unitOfWork;
        }

        public abstract Task<TM> Handle(TQ request, CancellationToken cancellationToken);
    }
}
