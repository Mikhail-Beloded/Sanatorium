using Microsoft.Extensions.DependencyInjection;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.DAL.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
