using System.Threading;
using System.Threading.Tasks;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Common.Abstractions.DataAccess;

namespace GhostProject.App.Core.Business.Companies.Interfaces;

public interface ICompanyRepository : IRepository<Company, int>
{

    public Task<Company> GetByLinkedInUrlAsync(string linkedInUrl, CancellationToken cancellationToken,
        bool asNoTracking = false);
    
    public Task<Company[]> GetByRecruiterIdAsync(int recruiterId, CancellationToken cancellationToken);
}
