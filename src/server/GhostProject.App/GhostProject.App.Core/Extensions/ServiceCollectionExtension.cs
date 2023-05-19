using System.Reflection;
using FluentValidation;
using GhostProject.App.Core.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GhostProject.App.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
