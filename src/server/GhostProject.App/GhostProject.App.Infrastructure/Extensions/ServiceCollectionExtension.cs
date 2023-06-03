using GhostProject.App.Core.Interfaces;
using GhostProject.App.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GhostProject.App.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IGoogleRecaptchaService, GoogleRecaptchaServiceService>();
        services.AddScoped<IEmailTemplateBuilder, EmailTemplateBuilder>();
        return services;
    }

}
