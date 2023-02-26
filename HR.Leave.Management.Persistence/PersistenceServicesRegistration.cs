using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Leave.Management.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRLeaveManagementDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("HRLeaveManagementConnectionString")));

            //options.UseSqlServer(connection, b => b.MigrationsAssembly("HR.Leave.Management.Application"))

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;
        }
    }
}