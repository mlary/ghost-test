using System;
using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.Core.Common.Abstractions.DataAccess;

namespace GhostProject.App.Core.Business.Rates.Interfaces;

public interface IRateRepository : IRepository<Rate, int>
{
    public Task<Rate> GetByConfirmationIdAsync(Guid confirmationId, CancellationToken cancellationToken);
}
