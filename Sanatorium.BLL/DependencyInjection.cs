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
            services.AddScoped<IStatisticsRepository, StatisticRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IVoucherService, VoucherService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IProcedureService, ProcedureService>();
            services.AddScoped<IIllnessService, IllnessService>();

            return services;
        }
    }
}