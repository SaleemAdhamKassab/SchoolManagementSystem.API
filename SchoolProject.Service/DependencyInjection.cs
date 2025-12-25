using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementations;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddServiceServices(this IServiceCollection services)
    {
        // Register infrastructure services here
        services.AddScoped<IStudentService, StudentService>();


        return services;
    }
}