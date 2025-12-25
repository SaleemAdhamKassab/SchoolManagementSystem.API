//namespace SchoolProject.Core;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Repositories;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;


public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        // Register infrastructure services here
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
