using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Services;
using Sanatorium.DAL.Context;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var conectionString = "Server = (localdb)\\mssqllocaldb; Database = SanatoriumDB; Trusted_Connection = True; TrustServerCertificate = true;";

            services.AddDbContext<EFContext>(options => options.UseSqlServer(conectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();

            return services;
        }
    }
}