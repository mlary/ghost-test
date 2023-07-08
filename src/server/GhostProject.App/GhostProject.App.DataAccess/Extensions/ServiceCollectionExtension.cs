using GhostProject.App.Core.Business.Companies.Interfaces;
using GhostProject.App.Core.Business.Rates.Interfaces;
using GhostProject.App.Core.Business.Recruiters.Interfaces;
using GhostProject.App.Core.Business.Users.Interfaces;
using GhostProject.App.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GhostProject.App.DataAccess.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecruiterRepository, RecruiterRepository>();

            return services;
        }
    }
}
