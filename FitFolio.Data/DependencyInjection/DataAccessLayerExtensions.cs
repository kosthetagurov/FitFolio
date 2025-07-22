using FitFolio.Data.Access;
using FitFolio.Data.Repositories;
using FitFolio.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitFolio.Data.DependencyInjection
{
    public static class DataAccessLayerExtensions
    {
        public static IServiceCollection AddFitFolioData(this IServiceCollection services, DataAccessLayerOptions options)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseNpgsql(options.ConnectionString);
            }, ServiceLifetime.Transient);

            services.AddTransient<RepositoryFactory>(provider =>
            {
                var context = provider.GetService<ApplicationDbContext>();

                return new RepositoryFactory(context);
            });

            var baseInterface = typeof(IRepository);
            var repositoryImpl = baseInterface
                .Assembly
                .GetTypes()
                .Where(type => type.IsClass 
                        && type.GetInterfaces().Contains(baseInterface)
                        && type.IsAbstract == false).ToList();

            foreach (var repository in repositoryImpl)
            {
                foreach (var repositoryInterface in repository.GetInterfaces()
                    .Where(i => i.GetInterfaces().Contains(baseInterface)))
                {
                    services.AddScoped(repositoryInterface, repository);
                    services.AddScoped(repository);
                }                    
            }

            return services;
        }
    }
}
