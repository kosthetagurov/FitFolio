using FitFolio.Data.Access;
using FitFolio.Data.Models;
using FitFolio.Data.Repositories;
using FitFolio.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
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
            }, ServiceLifetime.Scoped);            

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                // Настройки пароля
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Настройки блокировки
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                // Настройки пользователя
                options.User.RequireUniqueEmail = true;

                // Настройки входа
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

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
