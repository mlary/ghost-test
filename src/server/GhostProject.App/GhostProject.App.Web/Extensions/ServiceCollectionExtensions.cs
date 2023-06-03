using System;
using GhostProject.App.Core.Common;
using GhostProject.App.Core.Common.Abstractions.DataAccess;
using GhostProject.App.Core.Extensions;
using GhostProject.App.Core.Interfaces;
using GhostProject.App.DataAccess.Common;
using GhostProject.App.DataAccess.Extensions;
using GhostProject.App.Infrastructure.Extensions;
using GhostProject.App.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GhostProject.App.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.RegisterRepositories();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddInfrastructure();
            services.AddApplication();

            services.AddHttpClient<IGoogleRecaptchaService, GoogleRecaptchaServiceService>((_, client) =>
            {
                client.BaseAddress = new Uri("https://www.google.com/recaptcha/api/siteverify");
            });
            return services;
        }
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            return services;
        }
        
        
        public static IServiceCollection RegisterAppSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.Configure<RecaptchaSettings>(configuration.GetSection("RecaptchaSettings"));
            services.Configure<ConfirmationSettings>(configuration.GetSection("ConfirmationSettings"));
            return services;
        }

    }
}
