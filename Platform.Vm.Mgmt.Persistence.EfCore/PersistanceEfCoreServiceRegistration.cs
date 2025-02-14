using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Persistence.EfCore.Repositories;

namespace Platform.Vm.Mgmt.Persistence.EfCore
{
    public static class PersistanceEfCoreServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlatformVmMgmtDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PlatformVmMgmtConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IDataCentreRepository, DataCentreRepository>();
            services.AddScoped<IEnvironmentRepository, EnvironmentRepository>();
            services.AddScoped<IVlanRepository, VlanRepository>();

            return services;
        }
    }
}