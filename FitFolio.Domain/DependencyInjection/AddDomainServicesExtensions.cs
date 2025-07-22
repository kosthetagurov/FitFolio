using FitFolio.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace FitFolio.Domain.DependencyInjection
{
    public static class AddDomainServicesExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            var baseInterface = typeof(IDomainService);
            var serviceImpl = baseInterface
                .Assembly
                .GetTypes()
                .Where(type => type.IsClass && type.GetInterfaces().Contains(baseInterface) 
                        && type.IsAbstract == false).ToList();

            foreach (var service in serviceImpl)
            {
                foreach (var serviceInterface in service
                    .GetInterfaces()
                    .Where(i => i.GetInterfaces().Contains(baseInterface)))
                {
                    services.AddScoped(serviceInterface, service);
                    services.AddScoped(service);
                }
            }

            return services;
        }
    }
}
