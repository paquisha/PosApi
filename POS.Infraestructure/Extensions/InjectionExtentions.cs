using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infraestructure.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Infraestructure.Persistences.Repositories;

namespace POS.Infraestructure.Extensions
{
    public static class InjectionExtentions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            var assembly = typeof(PosContext).Assembly.FullName;
            service.AddDbContextPool<PosContext>(
                optionsAction: options => options.UseSqlServer(
                    connectionString: configuration.GetConnectionString(name: "cadenaSql"), sqlServerOptionsAction: b => b.MigrationsAssembly(assemblyName: assembly)), poolSize: (int)ServiceLifetime.Transient);
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return service;
        }
    }
}
