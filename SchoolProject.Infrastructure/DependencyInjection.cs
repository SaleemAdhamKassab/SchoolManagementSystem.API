using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Repositories;

//namespace SchoolProject.Infrastructure;
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Register infrastructure services here
        services.AddScoped<IStudentRepository, StudentRepository>();

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}